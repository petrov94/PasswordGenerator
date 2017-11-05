using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cursework
{
    class PasswordVM : DependencyObject
    {
        public Password Password_OBJ { get; set; }
        readonly string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly string lowercase = "abcdefghijklmnopqrstuvwxyz";
        readonly string numbers = "0123456789";
        readonly string sumbols = ".,;:@?!\\/*&'^~=#()+-";

        private ICommand generatePasswordCommand { get; set; }
        private ICommand genereteSimplePassCommand { get; set; }
        private ICommand validatePasswordCommand { get; set; }
        public PasswordVM()
        {
            Password_OBJ = new Password();
            generatePasswordCommand = new RelayCommand(genereteAPass);
            genereteSimplePassCommand = new RelayCommand(generateSimplePass);
            validatePasswordCommand = new RelayCommand(validatePass);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        

        public ICommand GenereteNewPasswordCommand
        {
            get
            {
                return generatePasswordCommand;
            }
            set
            {
                generatePasswordCommand = value;
            }
        }
        public ICommand GenereteSimplePasswordCommand
        {
            get
            {
                return genereteSimplePassCommand;
            }
            set
            {
                genereteSimplePassCommand = value;
            }
        }
        public ICommand ValidatePasswordCommand
        {
            get
            {
                return validatePasswordCommand;
            }
            set
            {
                validatePasswordCommand = value;
            }
        }
        private void genereteAPass(object obj)
        {
            StringBuilder pass = new StringBuilder();
            int size;
            string symbols;
            if (String.IsNullOrEmpty(Password_OBJ.Length)) { Password_OBJ.Outputtring = "The size is not entered"; return; }
            if (string.IsNullOrEmpty(Password_OBJ.Exclude))
            {
                symbols = "";
            }
            else
            {
                symbols = Password_OBJ.Exclude;
            }
            if (Int32.TryParse(Password_OBJ.Length, out size))
            {
                if (size > 45) { Password_OBJ.Outputtring = "The maximum size ot password is 45"; return; }
                StringBuilder possiblecharecters = new StringBuilder();
                Random random = new Random();
                bool CheckSymbols = Password_OBJ.IsCheckedSymbol;
                bool CheckNumbers = Password_OBJ.IsCheckedNumbers;
                bool CheckLowerCase = Password_OBJ.IsCheckedLowerCase;
                bool CheckUpperCase = Password_OBJ.IsCheckedUpperCase;
                if (CheckSymbols)
                {
                    String possiblesymbols = removesymbols(symbols, sumbols);
                    if(String.IsNullOrEmpty(possiblesymbols)) { Password_OBJ.Outputtring = "Have to remove Symbols from excluded textfiled to be included in password"; return; }
                    int Symbol = random.Next(0, possiblesymbols.Length);
                    char sym = possiblesymbols[Symbol];
                    pass.Append(sym);
                    possiblecharecters.Append(possiblesymbols);
                }
                if (CheckNumbers)
                {
                    String possiblenumbers = removesymbols(symbols, numbers);
                    if (String.IsNullOrEmpty(possiblenumbers)) { Password_OBJ.Outputtring = "Have remove Numbers from excluded textfiled to be included in password"; return; }
                    int Symbol = random.Next(0, possiblenumbers.Length);
                    char sym = possiblenumbers[Symbol];
                    pass.Append(sym);
                    possiblecharecters.Append(possiblenumbers);
                }
                if (CheckLowerCase)
                {
                    String possibleLowerCase = removesymbols(symbols, lowercase);
                    if (String.IsNullOrEmpty(possibleLowerCase)) { Password_OBJ.Outputtring = "Have to remove Lower Case Letters from excluded textfiled to be included in password"; return; }
                    int Symbol = random.Next(0, possibleLowerCase.Length);
                    char sym = possibleLowerCase[Symbol];
                    pass.Append(sym);
                    possiblecharecters.Append(possibleLowerCase);
                }
                if (CheckUpperCase)
                {
                    String possibleUpperCase = removesymbols(symbols, uppercase);
                    if (String.IsNullOrEmpty(possibleUpperCase)) { Password_OBJ.Outputtring = "Have to remove Upper Case Letters from excluded textfiled to be included in password"; return; }
                    int Symbol = random.Next(0, uppercase.Length);
                    char sym = possibleUpperCase[Symbol];
                    pass.Append(sym);
                    possiblecharecters.Append(possibleUpperCase);
                }
                if (String.IsNullOrEmpty(possiblecharecters.ToString())) { Password_OBJ.Outputtring = "No one criteria is choosen"; return; }

                int leftsize = size - pass.Length;
                String possible = possiblecharecters.ToString();
                String additional = Password_OBJ.GeneretePass(leftsize, possible);
                String finalpass = pass.ToString() + additional;
                String Finalpass = Shuffle(finalpass);
                Password_OBJ.Outputtring = finalpass;
            }
            else { Password_OBJ.Outputtring = "YOU HAVE TO ENTER A VALID LENGHT OF A PASSWORD"; return; }
        }
        private string Shuffle(string list)
        {
            Random R = new Random();
            int index;
            List<char> chars = new List<char>(list);
            StringBuilder sb = new StringBuilder();
            while (chars.Count > 0)
            {
                index = R.Next(0,chars.Count);
                sb.Append(chars[index]);
                chars.RemoveAt(index);
            }
            return sb.ToString();
        }
        private String removesymbols(string symbols, string allpossiblities)
        {
            foreach (Char sumbol in symbols)
            {
                foreach (char allpos in allpossiblities)
                {
                    if (string.Equals(sumbol.ToString(), allpos.ToString(), StringComparison.Ordinal))
                    {
                        int possition = allpossiblities.IndexOf(allpos);
                        allpossiblities = allpossiblities.Remove(possition, 1);
                        break;
                    }
                }
            }
            return allpossiblities;
        }
        

        private void generateSimplePass(object obj)
        {
            int size;
            if (Int32.TryParse(Password_OBJ.Length, out size))
            {
                if (size > 45) { Password_OBJ.OutputtringInSimple = "The maximum size ot password is 45"; return; }
                PassModel model = new PassModel();
                ObservableCollection<string> alllines = model.GetData();
               
                foreach (string line in alllines)
                {
                    if (size > line.Length)
                    {
                        int sizepass = size - line.Length;
                        String addpass = Password_OBJ.generatesimple(sizepass, sumbols + numbers);
                        String newpass = line + addpass;
                        Password_OBJ.OutputtringInSimple = newpass;
                    }

                }
            }
            else { Password_OBJ.OutputtringInSimple = "YOU HAVE TO ENTER A VALID LENGHT OF A PASSWORD"; }
        }

        private void validatePass(object obj)
        {
            String pass = Password_OBJ.Validation;
            int size;
            if (String.IsNullOrEmpty(Password_OBJ.Length)) { Password_OBJ.ValidationOutput = "The size is not entered"; return; }
            if (!Int32.TryParse(Password_OBJ.Length, out size)) { Password_OBJ.ValidationOutput = "YOU HAVE TO ENTER A VALID LENGHT OF A PASSWORD"; return; }
            if (size > 45) { Password_OBJ.ValidationOutput = "The maximum size ot password is 45"; return; }
            if (String.IsNullOrEmpty(Password_OBJ.Validation)) { Password_OBJ.ValidationOutput = "Password is not entered"; return; }
            bool ALLChecks = false;
            bool CheckSymbols = Password_OBJ.IsCheckedSymbolInValidation;
            bool CheckNumbers = Password_OBJ.IsCheckedNumbersInValidation;
            bool CheckLowerCase = Password_OBJ.IsCheckedLowerCaseInValidation;
            bool CheckUpperCase = Password_OBJ.IsCheckedUpperCaseInValidation;
            if (CheckSymbols)
            {
                bool b = CheckALL(pass, sumbols);
                if (b) ALLChecks = true;
                else { ALLChecks = false; Password_OBJ.ValidationOutput = "Password doesn't contains sumbols"; return; }
            }
            if (CheckNumbers)
            {
                bool b = CheckALL(pass, numbers);
                if (b) ALLChecks = true;
                else { ALLChecks = false; Password_OBJ.ValidationOutput = "Password doesn't contains numbsers"; return; }
            }
            if (CheckLowerCase)
            {
                bool b = CheckALL(pass, lowercase);
                if (b) ALLChecks = true;
                else { ALLChecks = false; Password_OBJ.ValidationOutput = "Password doesn't contains lowercase letters"; return; }
            }
            if (CheckUpperCase)
            {
                bool b = CheckALL(pass, uppercase);
                if (b) ALLChecks = true;
                else { ALLChecks = false; Password_OBJ.ValidationOutput = "Password doesn't contains uppercase letters"; return; }
            }
            if (!ALLChecks) { Password_OBJ.ValidationOutput = "No creteria is choose"; return; }
            else {
                if(size>=pass.Length) Password_OBJ.ValidationOutput = "Password is Correct";
                else Password_OBJ.ValidationOutput = "Password is bigger than given size";
            }
        }
        private bool CheckALL(String pass, String parameters)
        {
            foreach (char ch in parameters)
            {
                bool b = pass.Contains(ch);
                if (b && (!pass.Contains(" "))) return true;
            }
            return false;
        }
    }
}