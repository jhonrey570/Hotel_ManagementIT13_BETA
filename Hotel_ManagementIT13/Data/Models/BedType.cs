namespace Hotel_ManagementIT13.Data.Models
{
    public class BedType
    {
        public int BedTypeId { get; set; }
        public string TypeName { get; set; } // This maps to bed_type_name in your database

        public override string ToString()
        {
            return TypeName;
        }
    }
}