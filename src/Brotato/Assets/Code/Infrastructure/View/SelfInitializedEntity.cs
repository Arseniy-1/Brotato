using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class SelfInitializedEntity : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;
        private IIdentifierService _identifierService;

        [Inject]
        public void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        private void Awake()
        {
            GameEntity entity = CreateEntity.Empty().AddId(_identifierService.Next());
            
            EntityBehaviour.SetEntity(entity);
        }
    }
}