using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers;
using System.Reflection;

namespace DiplomaProject.OpenDotaAPI.APIComposite
{
    public abstract class Component
    {
        protected PropertyInfo _field;
        protected IAPIModel _model;
        protected IAPIModel[] _models;
        protected Component _parent;
        protected APIParser _parser;
        public virtual IAPIModel APIModel { get { return _model; } }
        public Component(PropertyInfo field,IAPIModel model, APIParser parser) {
            _field = field;
            _model = model;
            _parser = parser;
        } 
        public Component(IAPIModel model, APIParser parser) {
            _model = model;
            _parser = parser;
        }
        protected Component(PropertyInfo field, IAPIModel[] model, APIParser parser) {
            _field = field;
            _models = model;
            _parser = parser;
        }
        public Component() {
        
        }
       
        public abstract void Operation();
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual void SetParent(Component parent) {
            _parent = parent;
        } 
        
        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual bool IsComposite()
        {
            return true;
        }
    }
}
