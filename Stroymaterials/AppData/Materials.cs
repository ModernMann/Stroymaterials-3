//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stroymaterials.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materials
    {
        public int id_materials { get; set; }
        public string materials_name { get; set; }
        public string materials_units { get; set; }
        public int materials_count { get; set; }
        public int materials_category { get; set; }
        public double materials_price { get; set; }
        public int materials_providers { get; set; }
        public int materials_makers { get; set; }
        public string materials_description { get; set; }
        public int materials_available { get; set; }
        public string materials_photo { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Makers Makers { get; set; }
        public virtual Providers Providers { get; set; }
    }
}