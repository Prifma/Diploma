using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers;
using System.Reflection;

namespace DiplomaProject.OpenDotaAPI.APIComposite
{
    public class LeafArray : Component
    {
       

        public LeafArray(PropertyInfo field, IAPIModel[] model, APIParser parser) : base(field, model, parser)
        {
        }

        public override void Operation()
        {
           _models = _parser.ParseToArray();
            if (_parent != null) {
                _field.SetValue(_parent.APIModel, _models);
            }
        }
    }
}
