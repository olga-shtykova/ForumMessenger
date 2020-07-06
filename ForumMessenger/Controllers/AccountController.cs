using ForumMessenger.Models;
using ForumMessenger.DAL;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ForumMessenger.Security;

namespace ForumMessenger.Controllers
{
    public class AccountController : Controller
    {
        private readonly MessageExchangeContext _db = new MessageExchangeContext();

        [HttpGet]        
        public ActionResult Login()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {            
            // при попытке повторного входа авторизованного пользователя
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // ищем пользователя с заданным логином и паролем
                var user = _db.Users
                    .FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                // если он есть - перенаправляем его на ListChats
                if (user != null)
                {
                    // аутентификация пользователя
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("ListChats", "Home");
                }

                ModelState.AddModelError("", "Неправильный логин или пароль!");
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            // при попытке регистрации авторизованного пользователя
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {          
            // устанавливаем для нового пользователя роль user вручную
            model.Role = "user";

            if (ModelState.IsValid)
            {
                // ищем пользователя с заданным логином
                var user = _db.Users
                    .FirstOrDefault(u => u.Login == model.Login);

                // если логин свободен - создаем пользователя
                if (user == null)
                {
                    // сохраняем пользователя в базе данных
                    _db.Users.Add(new User { Name = model.Name, Surname = model.Surname, Login = model.Login, Password = model.Password, Email = model.Email, Role = model.Role });
                    _db.SaveChanges();

                    // проверяем, что пользователь создан
                    user = _db.Users
                        .FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                    // если пользователь создан - перенаправляем его на ListChats
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("ListChats", "Home");
                    }
                }               

                ModelState.AddModelError("", "Логин занят!");
            }
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult ListUsers()
        {           
            // передаем в представление ListUsers.cshtml список пользователей
            return View(_db.Users);
        }        

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            // ищем пользователя по id 
            var u = _db.Users.Find(id);

            if (u != null)
            {
                // передаем в представление найденного пользователя
                return View(u);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditUser(string actionType, User u)
        {
            if (actionType == "Сохранить")
            {
                // сохраняем изменения в базе данных
                _db.Entry(u).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else if(actionType == "Отмена")
            {
                // от измененяемния в базе данных    
                _db.Entry(u).State = EntityState.Unchanged;              
            }
            return RedirectToAction("ListUsers", "Account");
        }                  

        [Authorize(Roles = "admin")]
        public ActionResult DeleteUser(int id)
        {
            // создаем пользователя по заданному id 
            var u = new User { Id = id };
            // удаляем его и сохраняем изменения
            _db.Entry(u).State = EntityState.Deleted;
            _db.SaveChanges();

            return RedirectToAction("ListUsers", "Account");
        }
        public ActionResult UnAuthorized()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}