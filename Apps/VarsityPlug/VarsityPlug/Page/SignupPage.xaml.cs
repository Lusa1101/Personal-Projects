//using Foundation;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VarsityPlug.Models;
using VarsityPlug;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VarsityPlug
{
    public partial class SignupPage : ContentPage
    {
        //Variable used to check the entered values
        int IDNoLength = 9;
        int cellLength = 10;
        int passwordLength = 8;

        Connect data = new Connect();

        public SignupPage() 
        {
            InitializeComponent();

            name.TextChanged += NameCheck;
            surname.TextChanged += SurnameCheck;
            number.TextChanged += IDNoCheck;
            cell.TextChanged += CellCheck;
            password1.TextChanged += PasswordStrength1;
            password2.TextChanged += PasswordStrength2;
        }

        private async void OnSignUp(object sender, EventArgs e)
        {
            bool pass = CheckInputs();

            if (!pass)
                return;

            Person? person = new Person
            {
                Name = name.Text,
                Id = Int32.Parse(number.Text),
                Surname = surname.Text,
                Cell = cell.Text,
                Password = password1.Text,
                Email = email.Text,
            };
            
            data.AddUser(person);

            DisplaySuccess(person.Id);

            //Print all the users
            foreach(Person person1 in data.ReturnPeople())
                Debug.WriteLine(person1);
        }

        async void DisplaySuccess(int id)
        {
            Person? person = data.ReturnPerson(id.ToString());

            if (person is null)
                await DisplayAlert("Alert", "Rgistration Failed.", "Okay");

            else
            {
                await DisplayAlert("Alert", $"Your registration was a success. \n{person.Id} {person.Password}", "Okay");
                await Navigation.PushAsync(new MainPage());
            }
            
        }

        bool CheckInputs()
        {
            //Variable to check if all the required information is provided
            bool pass = false;

            if (nameCheck.ToString().Length == 0)
            {
                nameCheck.Text = "Missing value";
                nameCheck.IsVisible = true;

                pass = false;
            }
            else
            {
                pass = true;
            }

            if(surnameCheck.ToString().Length == 0)
            {
                surnameCheck.Text = "Missing value";
                surnameCheck.IsVisible = true;

                pass = false;
            }
            else
            {
                pass = true;
            }

            if(number.ToString().Length == 0)
            {
                IDCheck.Text = "Missing value";
                IDCheck.IsVisible = true;

                pass = false;
            }
            else
            {
                pass = true;
            }

            if(email.ToString().Length == 0)
            {
                emailCheck.Text = "Please ensure that you have inserted you name, surname and your university ID. " +
                    "If you did, make sure you have selected whether you are a student or staff.";
                emailCheck.IsVisible = true;

                pass = false;
            }
            else
            {
                pass = true;
            }

            if(!PasswordCheck(password1.Text, password2.Text) || 
                password1.ToString().Length == 0 ||
                password2.ToString().Length == 0)
            {
                passwordCheck.Text = "Please ensure that the passwords are filled and are the same";
                passwordCheck.IsVisible = true;

                pass = false;
            }
            else
            {
                pass = true;
            }

            if(cell.ToString().Length == 0)
            {
                cellCheck.Text = "Please enter your cell.";
                cellCheck.IsVisible = true;

                pass = false;
            }
            else
            {
                pass = true;
            }

            return pass;
        }

        private void OnPassword2Eye(object sender, EventArgs e)
        {
            //password1.IsPassword = false;

            if (password2.IsPassword == false)
            {
                password2Image.Source = "icons8_eye.png";
                password2.IsPassword = true;
            }

            else
            {
                password2Image.Source = "icons8_closed_eye.png";
                password2.IsPassword = false;

            }
        }

        private void OnPassword1Eye(object sender, EventArgs e)
        {
            //password1.IsPassword = false;

            if (password1.IsPassword == false)
            {
                password1Image.Source = "icons8_eye.png";
                password1.IsPassword = true;
            }

            else
            {
                password1Image.Source = "icons8_closed_eye.png";
                password1.IsPassword = false;

            }
        }

        bool PasswordCheck(string pass1, string pass2)
        {
            bool pass = (pass1 == pass2);

            if(!pass)
            {
                passwordCheck.IsVisible = true;
                return false;
            }
            else
            {
                passwordCheck.IsVisible = false;
                return true;
            }
        }

        private bool stringCheck(string text1, string text2)
        {
            for(int i = 0; i < text1.Length; i++)
            {
                for(int j = 0; j < text2.Length; j++)
                {
                    if (text1[i] == text2[j])
                        return true;
                }
            }

            return false;
        }

        void PasswordStrength1(object sender, TextChangedEventArgs e)
        {
            bool containsNumber = false;
            bool containsSpecialChar = false;
            bool containsCapitalLetter = false;
            bool containsLowerCase = false;

            string specialCharacter = "~!@:#$%^&*()_-+{}[]=\"\'\\/.,<>`|";

            if(e.NewTextValue.Length == 0)
            {
                password1Layout.IsVisible = false;
                return;
            }
            else
                password1Layout.IsVisible = true;

            if (e.NewTextValue.Any(c => char.IsAsciiDigit(c)))
            {
                containsNumber = true;
                numericlImg1.IsVisible = true;
            }
            else
            {
                containsNumber = false;
                numericlImg1.IsVisible = false;
            }

            if(e.NewTextValue.Any(c => char.IsAsciiLetterUpper(c)))
            {
                containsCapitalLetter = true;
                capitalImg1.IsVisible = true;
            }
            else
            {
                containsCapitalLetter = false;
                capitalImg1.IsVisible = false;
            }

            if (e.NewTextValue.Any(c => char.IsAsciiLetterLower(c)))
            {
                containsLowerCase = true;
                lowerImg1.IsVisible = true;
            }
            else
            {
                containsLowerCase = false;
                lowerImg1.IsVisible = false;
            }

            if (stringCheck(e.NewTextValue, specialCharacter))
            {
                containsSpecialChar = true;
                specialImg1.IsVisible = true;
            }
            else
            {
                containsSpecialChar = false;
                specialImg1.IsVisible = false;
            }

            if (containsSpecialChar && containsNumber && containsLowerCase && containsCapitalLetter && (e.NewTextValue.Length >= passwordLength))
                password1Layout.IsVisible = false;
            else
                password1Layout.IsVisible = true;

        }

        void PasswordStrength2(object sender, TextChangedEventArgs e)
        {
            bool containsNumber = false;
            bool containsSpecialChar = false;
            bool containsCapitalLetter = false;
            bool containsLowerCase = false;

            string specialCharacter = "~!@#$%^&:*()_+{}[]=\"\'\\/.,<>`|";

            if (e.NewTextValue.Length == 0)
            {
                password2Layout.IsVisible = false;
                return;
            }
            else
                password2Layout.IsVisible = true;

            if (e.NewTextValue.Any(c => char.IsAsciiDigit(c)))
            {
                containsNumber = true;
                numericlImg2.IsVisible = true;
            }
            else
            {
                containsNumber = false;
                numericlImg2.IsVisible = false;
            }

            if (e.NewTextValue.Any(c => char.IsAsciiLetterUpper(c)))
            {
                containsCapitalLetter = true;
                capitalImg2.IsVisible = true;
            }
            else
            {
                containsCapitalLetter = false;
                capitalImg2.IsVisible = false;
            }

            if (e.NewTextValue.Any(c => char.IsAsciiLetterLower(c)))
            {
                containsLowerCase = true;
                lowerImg2.IsVisible = true;
            }
            else
            {
                containsLowerCase = false;
                lowerImg2.IsVisible = false;
            }

            if (stringCheck(e.NewTextValue, specialCharacter))
            {
                containsSpecialChar = true;
                specialImg2.IsVisible = true;
            }
            else
            {
                containsSpecialChar = false;
                specialImg2.IsVisible = false;
            }

            if (containsSpecialChar && containsNumber && containsLowerCase && containsCapitalLetter && (e.NewTextValue.Length >= passwordLength))
                password2Layout.IsVisible = false;
            else
                password2Layout.IsVisible = true;

            //Ensuring that passwords are the same
            //PasswordCheck(password1.ToString(), e.NewTextValue);

        }

        void CellCheck(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length != cellLength)
            {
                cellCheck.Text = "Cell is invalid(ZA).";
                cellCheck.IsVisible = true;
            }
            else
                cellCheck.IsVisible = false;
        }

        void NameCheck(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Any(c => Char.IsAsciiDigit(c)))
            {
                nameCheck.Text = "Enter a valid name.";
                nameCheck.IsVisible = true;
            }
            else
                nameCheck.IsVisible = false;
        }

        void SurnameCheck(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Any(c => Char.IsAsciiDigit(c)))
            {
                surnameCheck.Text = "Enter a valid surname.";
                surnameCheck.IsVisible = true;
            }
            else
                surnameCheck.IsVisible = false;
        }

        void IDNoCheck(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length != IDNoLength)
            {
                IDCheck.Text = "Enter a valid university ID";
                IDCheck.IsVisible = true;
            }
            else
            {
                IDCheck.IsVisible = false;
                email.Text = StudentEmailGenerator(number.Text);
            }
        }

        void OnStudentTypeChange (object sender, CheckedChangedEventArgs e)
        {
            if(e.Value)
            {
                email.Text = StudentEmailGenerator(number.Text);
            }
            else
            {
                email.Text = StaffEmailGenerator(name.Text, surname.Text);
                
            }
        }

        string StudentEmailGenerator(string studentNumber)
        {
            string email = string.Empty;
            string domain = "@keyaka.ul.ac.za";

            email = studentNumber+domain;

            return email;
        }

        string StaffEmailGenerator(string name, string surname)
        {
            StringBuilder email = new StringBuilder();

            //Ensuring that the name and surname are of lower-cases
            if(name == null || name.Length == 0)
            {
                emailCheck.Text = "Please ensure that you have inserted you name, surname and your university ID. " +
                   "If you did, make sure you have selected whether you are a student or staff.";
                emailCheck.IsVisible = true;

                return "";
            }
            else
                name = name.ToLower();

            if(surname == null || surname.Length == 0)
            {
                emailCheck.Text = "Please ensure that you have inserted you name, surname and your university ID. " +
                   "If you did, make sure you have selected whether you are a student or staff.";
                emailCheck.IsVisible = true;

                return "";
            }
            else
                surname = surname.ToLower();

            emailCheck.IsVisible = false;

            email.Append(name);
            email.Append(".");
            email.Append(surname);
            email.Append("@ul.ac.za");

            return email.ToString();
        }
    }
}
