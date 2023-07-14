using System.ComponentModel.DataAnnotations;

namespace Sipay.FirstWeekHomework.SevvalBaskan.Models
{
	public class Person
    {
		/// Kullanıcıdan alacağımız bilgiler.

		public string Name { get; set; }
		public string Lastname { get; set; }
		public string Phone { get; set; }
		public int AccessLevel { get; set; }
		public decimal Salary { get; set; }
    }
}
