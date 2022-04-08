using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class QThemeController
    {
        private QThemeRepository qThemeRepository;

        public QThemeController(stuff_shopContext db)
        {
            qThemeRepository = new QThemeRepository(db);
        }

        public List<QTheme> GetThemes()
        {
            return qThemeRepository.Items.ToList();
        }

        public QTheme GetQTheme(int id)
        {
            return qThemeRepository.Get(id);
        }

        public QTheme GetQTheme(string name)
        {
            return qThemeRepository.GetByName(name);
        }

        public void AddQTheme(QTheme qTheme)
        {
            qThemeRepository.Add(qTheme);
        }

        public void UpdateTheme(QTheme theme)
        {
            qThemeRepository.Update(theme);
        }

        public void RemoveTheme(int id)
        {
            qThemeRepository.Remove(id);
        }
    }
}
