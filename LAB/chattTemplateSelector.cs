using System.Windows;
using System.Windows.Controls;

namespace LAB
{
    public class ChattTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
                FrameworkElement element = container as FrameworkElement;

                if (element != null && item != null && item is MessageObject)
                {
                    MessageObject listItem = item as MessageObject;

                    if (listItem.Type == "image")
                    {
                        return element.FindResource("ImageTemplate") as DataTemplate;
                    }
                    else
                    {
                        return element.FindResource("TextTemplate") as DataTemplate;
                    } 
                }
                return null;
            }
        }
    }

