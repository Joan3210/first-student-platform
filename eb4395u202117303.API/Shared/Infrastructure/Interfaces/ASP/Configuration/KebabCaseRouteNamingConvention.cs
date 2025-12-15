using eb4395u202117303.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace eb4395u202117303.API.Shared.Infrastructure.Interfaces.ASP.Configuration;

/// <summary>
///     A convention that transforms controller route templates to use kebab-case naming.
/// </summary>
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    /// <summary>
    ///     Applies the kebab-case naming convention to the controller's route templates.
    /// </summary>
    /// <param name="controller">The controller model to apply the convention to.</param>
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
    }

    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null
            ? new AttributeRouteModel
                { Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase()) }
            : null;
    }
}