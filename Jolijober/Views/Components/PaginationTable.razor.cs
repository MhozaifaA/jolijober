using Jolijober.Util.Translate;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.Views.Components
{
    public partial class PaginationTable
    {
        [Inject] public AppTranslate Translate{ get; set; }
        [Parameter] public int CurrentPage { get; set; } = 1;
        [Parameter] public int TotaPagesQuantity { get; set; }
        [Parameter] public int Radius { get; set; } = 3;
        [Parameter] public EventCallback<int> SelectedPage { get; set; }


        List<LinkModel> links;
        protected override void OnParametersSet()
        {
            LoadPages();
        }


        private async Task SelectedPageInternal(LinkModel link)
        {
            if (link.Page == CurrentPage)
            {
                return;
            }

            if (!link.Enabled)
            {
                return;
            }

            if (TotaPagesQuantity == 0)
            {
                return;
            }

            CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }

        private void LoadPages()
        {
            links = new List<LinkModel>();
            var isPreviousPageLinkEnabled = CurrentPage != 1;
            var previousPage = CurrentPage - 1;

       //     links.Add(new LinkModel(1, isPreviousPageLinkEnabled, "«"));

            links.Add(new LinkModel(previousPage, isPreviousPageLinkEnabled, Translate["Previous"]));

            for (int i = 1; i <= TotaPagesQuantity; i++)
            {
                if (i >= CurrentPage - Radius && i <= CurrentPage + Radius)
                {
                    links.Add(new LinkModel(i) { Active = CurrentPage == i });
                }
            }

            var isNextPageLinkEnabled = CurrentPage != TotaPagesQuantity;
            var nextPage = CurrentPage + 1;

            links.Add(new LinkModel(nextPage, isNextPageLinkEnabled, Translate["Next"]));

           // links.Add(new LinkModel(TotaPagesQuantity, isNextPageLinkEnabled, "»"));
        }

        class LinkModel
        {
            public LinkModel(int page)
                : this(page, true) { }

            public LinkModel(int page, bool enabled)
                : this(page, enabled, page.ToString())
            { }

            public LinkModel(int page, bool enabled, string text)
            {
                Page = page;
                Enabled = enabled;
                Text = text;
            }

            public string Text { get; set; }
            public int Page { get; set; }
            public bool Enabled { get; set; } = true;
            public bool Active { get; set; } = false;
        }
    }
}
