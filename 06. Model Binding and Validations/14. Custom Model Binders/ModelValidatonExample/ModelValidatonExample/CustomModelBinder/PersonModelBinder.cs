using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidatonExample.Models;

namespace ModelValidatonExample.CustomModelBinder
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();

            //FirstName and LastName
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.PersonName += bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
                {
                    person.PersonName += bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }

            //Email
            if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;

            //Password
            if (bindingContext.ValueProvider.GetValue("Password").Length > 0)
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;

            //ConfirmPassword
            if (bindingContext.ValueProvider.GetValue("ConfirmPassword").Length > 0)
                person.ConfirmedPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;

            //Phone
            if (bindingContext.ValueProvider.GetValue("Phone").Length > 0)
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;

            //Price
            if (bindingContext.ValueProvider.GetValue("Price").Length > 0)
                person.Price = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Price").FirstValue);

            //DateOfBirth
            if (bindingContext.ValueProvider.GetValue("DateOfBirth").Length > 0)
                person.DateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue);

            //ToDate
            if (bindingContext.ValueProvider.GetValue("ToDate").Length > 0)
                person.ToDate = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("ToDate").FirstValue);


            if (bindingContext.ValueProvider.GetValue("Age").Length > 0)
                person.Age = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Age").FirstValue);

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
