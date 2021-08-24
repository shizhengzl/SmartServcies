using System;
using System.Collections.Generic;
using System.Text;

namespace Core.SnippetServices
{
    public class SnippetTypes
    {
        public SnippetTypes() {
            SnippetType = new List<string>() { SnippetTypeEnum.Expansion.ToString() };
        }

        /// <summary>
        /// 
        /// </summary>
        public List<string> SnippetType { get; set; }
    }

}
