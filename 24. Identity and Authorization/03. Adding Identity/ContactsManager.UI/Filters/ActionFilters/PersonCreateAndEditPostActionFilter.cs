﻿using CRUDExample.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using ServiceContracts.DTO;

namespace CRUDExample.Filters.ActionFilters
{
 public class PersonCreateAndEditPostActionFilter : IAsyncActionFilter
 {
  private readonly ICountriesGetterService _countriesService;
  private readonly ILogger<PersonCreateAndEditPostActionFilter> _logger;


  public PersonCreateAndEditPostActionFilter(ICountriesGetterService countriesService, ILogger<PersonCreateAndEditPostActionFilter> logger)
  {
   _countriesService = countriesService;
   _logger = logger;
  }

  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
   //TO DO: before logic

   if (context.Controller is PersonsController personsController)
   {
    if (!personsController.ModelState.IsValid)
    {
     List<CountryResponse> countries = await _countriesService.GetAllCountries();
     personsController.ViewBag.Countries = countries.Select(temp =>
     new SelectListItem() { Text = temp.CountryName, Value = temp.CountryID.ToString() });

     personsController.ViewBag.Errors = personsController.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

     var personRequest = context.ActionArguments["personRequest"];

     context.Result = personsController.View(personRequest); //short-circuits or skips the subsequent action filters & action method
    }
    else
    {
     await next(); //invokes the subsequent filter or action method
    }
   }
   else
   {
    await next(); //calls the subsequent filter or action method
   }

   //TO DO: after logic
   _logger.LogInformation("In after logic of PersonsCreateAndEdit Action filter");
  }
 }
}
