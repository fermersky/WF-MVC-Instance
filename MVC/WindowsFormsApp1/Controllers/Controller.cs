using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Views;
using System.Windows.Forms;


namespace WindowsFormsApp1.Controllers
{
    public class Controller
    {
        private IView view;
        private Model model;
        public Model Model
        {
            get { return model; }
        }
        public Controller()
        {
            model = new Model();
        }
        public Form CreateForm()
        {
            Form1 form = new Form1();
            view = form;
            view.Controller = this;
            form.Show();
            return form;
        }

        public void Add(Person person)
        {
            model.Add(person);
        }

        public void Load()
        {
            Model.Load();
        }

        public void Edit(Person pers, int index)
        {
            Model.Edit(pers, index);
        }
    }
}
