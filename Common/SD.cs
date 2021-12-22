using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        public const string Role_User = "User";
        public const string Role_Customer = "Customer";

        public const string CrimeSubmitText1 = "Submit: Please submit valid and truthful information only. Multiple submissions will not be allowed. Each registered user will be able to submit no more than two submissions per month.";
        public const string CrimeSubmitText2 = "Address: Please select a province, city and suburb from the dropdown lists provided. Street name is required, you are not obligated to provide unit/property/house numbers.";
        public const string CrimeSubmitText3 = "GeoCoding: GeoCoding uses the address details provided to place a marker on the map therefore it is reccomended to provide as much detail as possible i.e '1st Street','1st Avenue', Peter Road or 14 Peter Road.";
        public const string CrimeSubmitText4 = "Type of Crime: Select the closest matching type available from the provided dropdown.";
        public const string CrimeSubmitText5 = "Date and Details: Select the date that the crime was committed. Details are not required but could be of use to other system users. Possible details: Description of persons that commited the crime, items or tools used to commit the crime.";
        public const string CrimeSubmitText6 = "True and Honest: Supplied information like suburb and street names will be used to send alerts to other users. Please do not report false crimes. Registered user information will not be visible via any part of the apllication.";

        public const string Local_Token = "JWT Token";
        public const string Local_UserDetails = "User Details";
        public const int TokenLifeInDays = 1;
        public const int SubmissionCount = 2;

        public const string TwoFaKey = "lsdfkjHASDKkjhfijir7788422562@#h%1123W";
        public const string APIGeo = "AIzaSyAoljylNNfvCee28OD3tHGgAayv7nJtlg4";
        public const string ReCaptchaKey = "6LdwoJgdAAAAAFpP9IiUTptkP2c9kY4Uk5tAw-OA";

        public const string SubscriptionPublic_key = "BPFwQhPuYLoIlDllaKqw9NgnpZg6M00h2ZtWek5iTB8QD_aeg00h523emFhwJfudvgm2qSHf5_QK2O9S4K6auAE";
        public const string SubscriptionPrivate_key = "zfGeWbU5nIw0HNR6pb0snfk167oaArCoN6g6BUJiseg";
        public const string Subscription_email = "mailto:<francois.bruere@gmail.com>";

        public const string TempLink = "https://localhost:7141/login";
    }
}
