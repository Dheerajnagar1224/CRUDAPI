using System;
using System.Collections.Generic;

public class EntityDto
{
    public string Id { get; set; }
    public bool Deceased { get; set; }
    public string Gender { get; set; }
    public List<AddressDto> Address { get; set; }
    public List<DateDto> Dates { get; set; }
    public List<NameDto> Names { get; set; }
}

public class AddressDto
{
    public string AddressLine { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public class DateDto
{
    public string DateType { get; set; }
    public DateTime? DateValue { get; set; }
}

public class NameDto
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Surname { get; set; }
}
