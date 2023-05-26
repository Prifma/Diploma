using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers;
using System.Reflection;

namespace DiplomaProject.OpenDotaAPI.APIComposite
{
    class Leaf : Component
    {
        public Leaf(FieldInfo field, IAPIModel model, APIParser parser) : base(field, model, parser)
        {
        }
        public Leaf (IAPIModel model, APIParser parser) : base( model, parser)
        {
        }

        public override void Operation()
        {
            _model = _parser.Parse();
            if(_parent is not null)
                _field.SetValue(_parent.APIModel, _model);
        }

        public override bool IsComposite()
        {
            return false;
        }
    }
}
