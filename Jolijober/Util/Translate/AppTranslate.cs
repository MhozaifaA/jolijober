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
            { "Remember me", "تذكرني"},
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
            { "About", "حول"},
            { "Cancel", "إلغاء"},
            { "Submit", "تأكيد"},
            { "Type Question Here", "اكتب السؤال هنا"},
            { "Description", "الوصف"},
            { "Your Answer", "قم بالرد"},
            { "Post Answer", "إرسال"},
            { "Preview", "رجوع"},
            { "Home", "الرئيسية"},
            { "Companies", "الشركات"},
            { "Company Profile", "صفحة الشركة"},
            { "Projects", "المشاريع"},
            { "Profiles", "الصفحات"},
            { "User Profile", "صفحة المستخدم"},
            { "my-profile-feed", "صفحتي الشخصية "},
            { "all-profile", "الصفحات"},
            { "Messages", "الرسائل"},
            { "Setting", "الإعدادات"},
            { "Clear all", "حذف الكل"},
            { "View All Messsages", "عرض كل الرسائل"},
            { "Notification", "الإشعارات"},
            { "View All Notification", "عرض كل الإشعارات"},
            { "Online Status", "حالة الإتصال"},
            { "Online", "متصل"},
            { "Offline", "غير متصل"},
            { "Custom Status", "الحالة"},
            { "Ok", "موافق"},
            { "Account Setting", "إعدادات الحساب"},
            { "Privacy", "الخصوصية"},
            { "Faqs", "الأسئلة الشائعة"},
            { "Terms & Conditions", "القواعد والشروط"},
            { "Logout", "تسجيل الخروج"},
            { "Comment on your project", "قام بتعليق على مشروعك"},
            { "Following", "تتابع"},
            { "Followers", "المتابعين"},
            { "View Profile", "مشاهدة الحساب"},
            { "View More", "عرض المزيد"},
            { "Post a Project", "طرح مشروع"},
            { "Post a Job", "نشر فرصة عمل"},
            { "Title", "العنوان"},
            { "Skills", "المهارات"},
            { "Price", "الراتب"},
            { "Post", "نشر"},
            { "Full Time", "دوام كامل"},
            { "Half Time", "دوام جزئي"},
            { "Edit Post", "تعديل المنشور"},
            { "Unsaved", "عدم حفظ"},
            { "Unbid", "حجب"},
            { "Close", "إغلاق"},
            { "Hide", "إخفاء"},
            { "hr", "سا"},
            { "Like", "إعجاب"},
            { "Comment", "تعليق"},
            { "Top Profiles", "الحسابات المقترحة"},
            { "Follow", "متابعة"},
            { "hire", "منح"},
            { "Send", "ارسال"},
            { "Post a comment", "اكتب تعليقاً"},
            { "Most Viewed People", "الأشخاص الأكثر مشاهدة"},
            { "Top Jobs", "أفضل الوظائف"},
            { "Most Viewed This Week", "الأكثر مشاهدة هذا الأسبوع"},
            { "See All", "عرض الكل"},
            { "Search", "بحث"},
            { "Search keywords", "بحث عن كلمة أو عبارة"},
            { "Filters", "فلترة"},
            { "Clear all filters", "تهيئة"},
            { "Clear", "تهيئة"},
            { "Search skills", "بحث بالمهارات"},
            { "Availabilty", "امكانية الدوام"},
            { "Hourly", "ساعي"},
            { "Part Time", "دوام جزئي"},
            { "Job Type", "نوع العمل"},
            { "Select a job type", "اختر نوع عمل"},
            { "Pay Rate", "معدل الاجور"},
            { "Experience Level", "مستوى الخبرة"},
            { "Select a experience level", "اختر مستوى الخبرة"},
            { "Countries", "البلدان"},
            { "Select a country", "اختر دولة"},
            { "John Doe", "محمد التجريبي"},
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
