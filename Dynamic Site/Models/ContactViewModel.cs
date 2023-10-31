﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Dynamic_Site.Models
{
	[Keyless]
	public class ContactViewModel
	{

		//We can use Data Annotation to add validation to our model
		//This is useful when we have required fields or need certain kinds of information


		[Required(ErrorMessage = "*Name is required")]//Makes the field required
		public string? Name { get; set; }

		[Required(ErrorMessage = "*Name is required")]
		[DataType(DataType.EmailAddress)]//Certain formatting is expected
		public string? Email { get; set; }

		[Required(ErrorMessage = "*Subject is required")]
		public string? Subject { get; set; }

		[Required(ErrorMessage = "*Message is required")]
		[DataType(DataType.MultilineText)] //Denotes this field is larger than a standard textbox (<input> => <textarea>)
		public string? Message { get; set; }




	}
}
