using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CodeFirstMVC.Models
{
    public class Salarie
    {
		//Première façon de saisir la donnée membre et sa propriété.
		//private int sal_ID;

		//public int Sal_ID
		//{
		//	get { return sal_ID; }
		//	set { sal_ID = value; }
		//}

		[Key] //Clé primaire
		public int Sal_ID { get; set; }

		
		[Required]
		[MaxLength(200)]
		
		public string Sal_nom { get; set; }


		public int Sal_age { get; set; }


		[Required]
		[MaxLength]
		public string Sal_description { get; set; }








	}
}
