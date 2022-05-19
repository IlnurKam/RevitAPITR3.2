using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITR3._2
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var selectedRef = uidoc.Selection.PickObject(ObjectType.Element, "Выберите элемент");
            var selectedElement = doc.GetElement(selectedRef);

            if (selectedElement is Pipe)
            {
                Parameter LengthParameter1 = selectedElement.LookupParameter("Length");
                if (LengthParameter1.StorageType == StorageType.Double)
                {
                    TaskDialog.Show("Length1", LengthParameter1.AsDouble().ToString());
                }

                Parameter LengthParameter2 = selectedElement.get.Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                if (LengthParameter2.StorageType == StorageType.Double)
                {
                    TaskDialog.Show("Length2", LengthParameter2.AsDouble().ToString());
                }

                return Result.Succeeded;
            }
        }
    }
}
