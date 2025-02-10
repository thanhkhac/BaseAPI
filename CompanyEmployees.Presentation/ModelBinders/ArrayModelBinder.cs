using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CompanyEmployees.Presentation.ModelBinders
{
    public class ArrayModelBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //If ModelMetaData isn't Enumerable type => set ModelBindingResult false and return
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }
            //Get the value (a comma-separated string of GUIDs)
            var providedValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();
            if (string.IsNullOrEmpty(providedValue))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }
            
            //genericType is created to store the type the IEnumerable consist of (string?int?...)
            var genericType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
            //Create a converter to the type
            var converter = TypeDescriptor.GetConverter(genericType);
            //Get object Array
            var objectArray =
                providedValue.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => converter.ConvertFromString(x.Trim())).ToArray();
            
            var guidArray = Array.CreateInstance(genericType, objectArray.Length);
            objectArray.CopyTo(guidArray,0);
            bindingContext.Model = guidArray;
            
            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}