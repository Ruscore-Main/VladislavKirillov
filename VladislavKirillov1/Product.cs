//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VladislavKirillov1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public override string ToString()
        {
            return this.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Difficulty { get; set; }
        public int PreparationTime { get; set; }
        public int Amount { get; set; }
        public Nullable<int> WorkListId { get; set; }
    
        public virtual WorkList WorkList { get; set; }
    }
}
