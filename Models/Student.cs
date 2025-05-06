using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StudentManager.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "full name is required !!!")]
    [StringLength(100, ErrorMessage = "full name cannot exceed 100 characters")]
    [RegularExpression(@"[A-Z]+", ErrorMessage = "Only upper case characters are allowed.")]
    public string FullName { get; set; }

    [Range(1,120, ErrorMessage = "age must be between 1 and 120 years!")]
    public int Age { get; set; }
    

    [Required(ErrorMessage = "City is required !!!!!")]
    public string City { get; set; }

    [Required(ErrorMessage = "EnrollmentDate is required")]
    public DateTime EnrollmentDate { get; set; }
}