using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections;
using System.Resources;

namespace Jolijober.Util.Translate
{
    public class AppTranslate : IAppTranslate
    {
        public IReadOnlyDictionary<string, string> Translate { get; }

        public AppTranslate()
        {
            Translate = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>() {
            { "Category", "مومو" },
            { "Company", "شركة"},
            { "Company Name", "اسم الشركة"},
            { "Country", "البلد"},
            { "Forgot Password?", "نسيت كلمة المرور؟"},
            { "get a job now!", "احصل على وظيفة الآن!"},
            { "Get Started", "ابداء"},
            { "Jolijober, is a global freelancing platform and social networking where businesses and independent" +
            " professionals connect and collaborate remotely", "Jolijober ، هي عبارة عن منصة عالمية للعمل الحر وشبكات اجتماعية حيث تتواصل الشركات والمهنيون المستقلون ويتعاونون عن بُعد"},
            { "Language", "اللغة"},
            { "Login Via Social Account", "تسجيل الدخول عبر الحسابات"},
            { "Password", "كلمة المرور"},
            { "Privacy Policy", "سياسة خاصة"},
            { "Remember me", "تذكرنى"},
            { "Repeat Password", "أعد كلمة المرور"},
            { "Sign in", "تسجيل الدخول"},
            { "Sign up", "أنشئ حساب"},
            { "User", "مستخدم"},
            { "UserName", "اسم المتسخدم"},
            { "Yes, I understand and agree to the JolijoberTerms & Conditions.", "نعم ، أفهم وأوافق على شروط وأحكام jolijober"},
            { "Ask a question", "طرح سؤال"},
            { "Comment", "التعليقات"},
            { "Jobs", "وظائف"},
            { "Latest", "آخر"},
            { "Login", "تسجيل الدخول"},
            { "Next", "التالى"},
            { "Popular of Month", "الأكثر تفاعلا هذا الشهر"},
            { "Popular This Week", "الأكثر تفاعلا هذا الاسبوع"},
            { "Previous", "السابق"},
            { "Register", "تسجيل"},
            { "Search...", "بحث..."},
            { "Tags", "العلامات"},
            { "Top Company of the Week", "أفضل الشركات هذا الأسبوع"},
            { "Treading", "الدوس"},
            { "Unanswered", "لم يتم الرد عليها"},
            { "Users", "المستخدمون"},
            { "Views", "مشاهدة"},
            { "Vote", "التصويت"},

            });
        }
    }
}
