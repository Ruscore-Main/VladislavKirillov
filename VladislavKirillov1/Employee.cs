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
    
    public partial class Employee
    {
        public override string ToString()
        {
            return this.Login;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> ShopId { get; set; }
    
        public virtual WorkList WorkList { get; set; }
        public virtual Shop Shop { get; set; }
    }
}