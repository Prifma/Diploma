using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers;
using System.Reflection;

namespace DiplomaProject.OpenDotaAPI.APIComposite
{
    class Composite : Component
    {
        protected List<Component> _children = new List<Component>();
       

        public Composite(FieldInfo field, IAPIModel model, APIParser parser) : base(field, model, parser)
        {
        }
        public Composite(IAPIModel model, APIParser parser) : base(model, parser)
        {
        }
        public Composite(IAPIModel model) { 
            _model = model;
        }

        public override void Add(Component component)
        {
            component.SetParent(this);
            this._children.Add(component);
        }

        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }

        public override void Operation()
        {
            if(_parser is not null)
                _model = _parser.Parse();
            
            foreach (var child in this._children)
            {
                child.Operation();
            }
            if (_parent is not null)
                _field.SetValue(_parent.APIModel, _model);
        }
    }
}
