using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using Store.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class PersonController
    {
        private PersonRepository personRepository;
        private StringValidator stringValidator;
        private UserRoleRepository roleRepository;
        private CodeRepository codeRepository;

        public PersonController()
        {
            stuff_shopContext dbContext = new stuff_shopContext();
            personRepository = new PersonRepository(dbContext);
            roleRepository = new UserRoleRepository(dbContext);
            codeRepository = new CodeRepository(dbContext);
            stringValidator = new StringValidator();
        }

        public Person GetUser(int id)
        {
            return personRepository.Get(id);
        }

        public bool NewUser(string Email, string UserPassword, string PersonSurname,
            string PersonName, string PersonPatronymic, DateTime BirthDate, string Phone, 
            int RoleId, string CodeString = null)
        {
            var textInfo = new CultureInfo("ru-RU").TextInfo;
            UserRole role = roleRepository.Get(RoleId);
            if (role != null && (role.RoleName == "ROLE_USER" || codeRepository.GetByRole(role) != null && codeRepository.GetByRole(role).CodeString == CodeString)
                && stringValidator.IsCorrectEmail(Email) && stringValidator.IsCorrectInfo(UserPassword)
                && stringValidator.IsCorrectName(textInfo.ToTitleCase(PersonSurname))
                && stringValidator.IsCorrectName(textInfo.ToTitleCase(PersonName))
                && stringValidator.IsCorrectName(textInfo.ToTitleCase(PersonPatronymic))
                && stringValidator.IsPhoneNumber(Phone))
                {
                    Person user = new Person();
                    user.Email = Email;
                    user.UserPassword = BCrypt.Net.BCrypt.HashPassword(UserPassword);
                    user.PersonName = textInfo.ToTitleCase(PersonName);
                    user.PersonSurname = textInfo.ToTitleCase(PersonSurname);
                    user.PersonPatronymic = textInfo.ToTitleCase(PersonPatronymic);
                    user.Phone = Phone;
                    user.BirthDate = BirthDate;
                    user.Role = role;

                    personRepository.Add(user);

                    return true;
                }
            return false;
        }

        public Person FindPersonByEmail(string email)
        {
            if (stringValidator.IsCorrectEmail(email))
                return personRepository.GetByEmail(email);
            return null;
        }

        public void AddDetached(Person person)
        {
            personRepository.AddDetached(person);
        }

        public bool IsPasswordVerified(string enteredPassword, string actualHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, actualHash);
        }
    }
}
