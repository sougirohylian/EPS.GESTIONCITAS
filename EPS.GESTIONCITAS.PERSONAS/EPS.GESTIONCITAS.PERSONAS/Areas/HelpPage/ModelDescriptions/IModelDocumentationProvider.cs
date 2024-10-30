using System;
using System.Reflection;

namespace EPS.GESTIONCITAS.PERSONAS.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}