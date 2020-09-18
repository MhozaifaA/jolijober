using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections;
using System.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;

namespace Jolijober.Util.Translate
{
    public class AppTranslate //: IAppTranslate
    {

        public IReadOnlyDictionary<string, string> Translate { get;}

        protected string Language { get; set; }

        public string this[string i]
        {
            get { return Language == "ar" ? (Translate.GetValueOrDefault(i) ?? i) : i; }
        }

        private readonly IHttpContextAccessor _httpContextAccessor;


        public AppTranslate(IHttpContextAccessor httpContextAccessor )
        {
            _httpContextAccessor = httpContextAccessor;

            WriteCookie();

            Translate = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
            { "Jolijober", "منصة توظيف" },
            { "Category", "نوع" },
            { "Company", "شركة"},
            { "Company Name", "اسم الشركة"},
            { "Country", "البلد"},
            { "Forgot Password?", "نسيت كلمة المرور؟"},
            { "get a job now!", "احصل على وظيفة الآن!"},
            { "Get Started", "ابداء"},
            { "Jolijober, is a global freelancing platform and social networking where businesses and independent" +
            " professionals connect and collaborate remotely", "منصة توظيف ، هي عبارة عن منصة عالمية للعمل الحر وشبكات اجتماعية حيث تتواصل الشركات والمهنيون المستقلون ويتعاونون عن بُعد"},
            { "Language", ". اللغة ."},
            { "Login Via Social Account", "تسجيل الدخول عبر الحسابات"},
            { "Password", "كلمة المرور"},
            { "Privacy Policy", "سياسة الخصوصية"},
            { "Remember me", "تذكرنى"},
            { "Repeat Password", "أعد كلمة المرور"},
            { "Sign in", "تسجيل الدخول"},
            { "Sign up", "أنشئ حساب"},
            { "User", "مستخدم"},
            { "UserName", "اسم المتسخدم"},
            { "Yes, I understand and agree to the JolijoberTerms & Conditions.", "نعم ، أفهم وأوافق على شروط وأحكام منصة توظيف"},
            { "Ask a question", "طرح سؤال"},
            { "Comments", "التعليقات"},
            { "Jobs", "وظائف"},
            { "Latest", "آخر"},
            { "Login", "تسجيل الدخول"},
            { "Next", "التالى"},
            { "Popular of Month", "الأكثر تفاعلا هذا الشهر"},
            { "Popular This Week", "الأكثر تفاعلا هذا الاسبوع"},
            { "Previous", "السابق"},
            { "Register", "تسجيل"},
            { "Search...", "...بحث"},
            { "Tags", "العلامات"},
            { "Top Company of the Week", "أفضل الشركات هذا الأسبوع"},
            { "Treading", "الدوس"},
            { "Unanswered", "لم يتم الرد عليها"},
            { "Users", "المستخدمون"},
            { "Views", "مشاهدة"},
            { "Vote", "التصويت"},
            { "Copyright Policy", "سياسة حقوق النشر"},
            { "Abut", "حول"},
            });
        }


        private void WriteCookie()
        {
            Language = _httpContextAccessor.HttpContext.Request.Cookies[nameof(Translate)];
            if (string.IsNullOrEmpty(Language))
            {
                //  _JSRuntime.InvokeAsync<string>("blazorExtensions.WriteCookie", nameof(Translate), "en", "").GetAwaiter().GetResult();
                     CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(30*24*60);


                _httpContextAccessor.HttpContext.Response.Cookies.Append(nameof(Translate), "en", option);

                Language = "en";
            }

        }


        public void Refresh()
        {
            Language = _httpContextAccessor.HttpContext.Request.Cookies[nameof(Translate)];
        }

    }
}
