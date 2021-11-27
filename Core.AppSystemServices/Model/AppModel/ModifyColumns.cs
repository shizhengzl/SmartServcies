using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 编辑列示列
    /// </summary>
    [Description("编辑列示列")]
    public class ModifyColumns : ShowColumns
    {
        public EditorSource Source {  get; set; }
    }

    public class EditorSource {
        public EnumEditorSource Source { get; set; }

        public String Key {  get; set; }

        public String Value {  get; set; }

        public string Content {  get; set; }

        public String Rule { get; set; }
    }

    public enum EnumEditorSource
    { 
        Table,
        BaseData,
        SQL,
        Json
    }   
}
