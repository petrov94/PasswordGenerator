using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cursework
{
    class Password : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private String _InputString;
        public String InputString
        {
            get { return _InputString; }
            set
            {
                _InputString = value;
                NotifyPropertyChanged();
            }
        }
        private String _OutputtringInSimple;
        public String OutputtringInSimple
        {
            get { return _OutputtringInSimple; }
            set
            {
                _OutputtringInSimple = value;
                NotifyPropertyChanged();
            }
        }
        private String _Outputtring;
        public String Outputtring
        {
            get { return _Outputtring; }
            set
            {
                _Outputtring = value;
                NotifyPropertyChanged();
            }
        }
        private bool isCheckedSymbol;
        public bool IsCheckedSymbol
        {
            get
            {
                return this.isCheckedSymbol;
            }
            set
            {
                this.isCheckedSymbol = value;
                NotifyPropertyChanged();
            }
        }
        private bool isCheckedNumbers;
        public bool IsCheckedNumbers
        {
            get
            {
                return this.isCheckedNumbers;
            }
            set
            {
                this.isCheckedNumbers = value;
                NotifyPropertyChanged();
            }
        }
        private bool isCheckedSymbolInValidation;
        public bool IsCheckedSymbolInValidation
        {
            get
            {
                return this.isCheckedSymbolInValidation;
            }
            set
            {
                this.isCheckedSymbolInValidation = value;
                NotifyPropertyChanged();
            }
        }
        private bool isCheckedNumbersInValidation;
        public bool IsCheckedNumbersInValidation
        {
            get
            {
                return this.isCheckedNumbersInValidation;
            }
            set
            {
                this.isCheckedNumbersInValidation = value;
                NotifyPropertyChanged();
            }
        }
        private String exclude;
        public String Exclude
        {
            get
            {
                return this.exclude;
            }
            set
            {
                this.exclude = value;
                NotifyPropertyChanged();
            }
        }
        private bool isCheckedLowerCase;
        public bool IsCheckedLowerCase
        {
            get
            {
                return this.isCheckedLowerCase;
            }
            set
            {
                this.isCheckedLowerCase = value;
                NotifyPropertyChanged();
            }
        }
        private bool isCheckedUpperCase;
        public bool IsCheckedUpperCase
        {
            get
            {
                return this.isCheckedUpperCase;
            }
            set
            {
                this.isCheckedUpperCase = value;
                NotifyPropertyChanged();
            }
        }
        private bool isCheckedLowerCaseInValidation;
        public bool IsCheckedLowerCaseInValidation
        {
            get
            {
                return this.isCheckedLowerCaseInValidation;
            }
            set
            {
                this.isCheckedLowerCaseInValidation = value;
                NotifyPropertyChanged();
            }
        }
        private bool isCheckedUpperCaseInValidation;
        public bool IsCheckedUpperCaseInValidation
        {
            get
            {
                return this.isCheckedUpperCaseInValidation;
            }
            set
            {
                this.isCheckedUpperCaseInValidation = value;
                NotifyPropertyChanged();
            }
        }
        private String lenght;
        public String Length
        {
            get { return lenght; }
            set
            {
                lenght = value;
                NotifyPropertyChanged();
            }
        }
        private String validation;
        public String Validation
        {
            get { return validation; }
            set
            {
                validation = value;
                NotifyPropertyChanged();
            }
        }
        private String validationOutput;
        public String ValidationOutput
        {
            get { return validationOutput; }
            set
            {
                validationOutput = value;
                NotifyPropertyChanged();
            }
        }
        public String GeneretePass(int size, String possiblecharecters)
        {
            Random random = new Random();
            StringBuilder pass = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                int nextCharecter = random.Next(0, possiblecharecters.Length);
                char sym = possiblecharecters[nextCharecter];
                pass.Append(sym);
            }
            return pass.ToString();
        }
        public String generatesimple(int size, string possiblechrecters)
        {
            StringBuilder pass_add = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int sumbol = random.Next(0, possiblechrecters.Length);
                char sym = possiblechrecters[sumbol];
                pass_add.Append(sym);
            }
            return pass_add.ToString();
        }

    }
}
