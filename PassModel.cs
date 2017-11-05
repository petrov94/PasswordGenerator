using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Cursework
{
    class PassModel
    {

        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Petar\Documents\Visual Studio 2015\Projects\Cursework\Cursework\Passwordforeasygeneration.txt");

        private ObservableCollection<string> _data = new ObservableCollection<string>();
        public ObservableCollection<string> GetData()
        {
            foreach (String line in lines)
            {
                _data.Add(line);
            }
            return _data;
        }

    }
}
