﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Activity_01.Binding
{
    public class CheckNameBinding : IModelBinder
    {
        private readonly ILogger<CheckNameBinding> _logger;

        public CheckNameBinding(ILogger<CheckNameBinding> logger)
        {
            _logger = logger;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null) 
                throw new ArgumentNullException(nameof(bindingContext)); 

            string modelName = bindingContext.ModelName;
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if(valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string value = valueProviderResult.FirstValue;
            if(string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }
            var s = value.ToUpper();

            if(s.Contains("XXX"))
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName, 
                    "Cannot contain this pattern xxx."
                    );
                return Task.CompletedTask;
            }
            bindingContext.Result = ModelBindingResult.Success(s.Trim());

            return Task.CompletedTask;
        }
    }
}
