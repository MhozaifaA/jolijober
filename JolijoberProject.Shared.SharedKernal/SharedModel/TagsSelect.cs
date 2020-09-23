using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Shared.SharedKernal.SharedModel
{
    public class TagsSelect
    {
        public TagsSelect(string name,bool isSelect=false)
        {
            Name = name;
            IsSelect = isSelect;
        }
        public string Name { get; set; }
        public bool IsSelect { get; set; } = false;

    }
}
