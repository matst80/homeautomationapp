using System;
using System.Reflection;
using System.Linq;
using Xamarin.Forms.Internals;

namespace homeautomation.BL
{
    public class CopyAttribute : Attribute {
        public bool Exclude
        {
            get;
            set;
        }
        public string FromProperty { get; set; }
    }

    public interface IRunOnCopy {
        void DataCopied(object fromObject);
    }

    public static class Common
    {
        
        public static void MemberviseCopyTo(this object a, object b) {
            var aType = a.GetType();
            var bType = b.GetType();
            var copyAttr = typeof(CopyAttribute);
            foreach (var prpInfo in bType.GetProperties()) {
                
                if (prpInfo.CanWrite) {
                    var customAttr = prpInfo.GetCustomAttributes(copyAttr, true).OfType<CopyAttribute>().FirstOrDefault();
                    var copyFromName = prpInfo.Name;
                    if (customAttr==null || !customAttr.Exclude)
                    {
                        if (customAttr!=null && !string.IsNullOrEmpty(customAttr.FromProperty)) {
                            copyFromName = customAttr.FromProperty;
                        }
                        var fromProperty = bType.GetProperty(copyFromName);
						if (fromProperty != null && fromProperty.CanRead)
						{
                            var valueToAdd = fromProperty.GetValue(a, null);
                            if (valueToAdd!=null) {
                                prpInfo.SetValue(b,valueToAdd);
                            }
						}    
                    }

                }
            }
            var runOnCopy = b as IRunOnCopy;
            if (runOnCopy!=null) {
                runOnCopy.DataCopied(a);
            }
        }

    }
}
