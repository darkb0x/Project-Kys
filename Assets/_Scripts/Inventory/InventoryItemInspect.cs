using ProjectKYS.Infrasturcture.Services.Input;
using UnityEngine;

namespace ProjectKYS.Inventory
{
    public class InventoryItemInspect : MonoBehaviour
    {
        private const float CAMERA_DEFAULT_FOV = 60f;
        private const float CAMERA_ZOOM_FOV = 25f;

        [SerializeField] private float _rotationSpeed = 1f;
        [SerializeField] private Transform _itemParent;
        [Space]
        [SerializeField] private Camera _itemRenderCamera;
        [SerializeField] private float _changeFOVSpeed = 3f;

        private IInputService _inputService;
        private ItemComponent _item;
        private bool _isInspectingItem;
        private float _targetCameraFOV;

        public void Initialize(IInputService inputService)
        {
            _inputService = inputService;

            _inputService.GetPlayerInputHandler().InspectItemEvent += OnInspectItem;
            _inputService.GetUIInputHandler().StopItemInspectEvent += OnInspectItem;

            SetIsInspectingItem(false);
        }
        private void OnDestroy()
        {
            _inputService.GetPlayerInputHandler().InspectItemEvent -= OnInspectItem;
            _inputService.GetUIInputHandler().StopItemInspectEvent -= OnInspectItem;
        }

        private void Update()
        {
            _itemRenderCamera.fieldOfView = Mathf.Lerp(_itemRenderCamera.fieldOfView, _targetCameraFOV, _changeFOVSpeed * Time.deltaTime);

            if (_item == null)
                return;
            if (!_isInspectingItem)
                return;

            Vector2 input = _inputService.GetUIInputHandler().GetInspectDirection();
            _item.transform.Rotate(_itemParent.right, input.y * _rotationSpeed * Time.deltaTime, Space.World);
            _item.transform.Rotate(_itemParent.up, input.x * _rotationSpeed * Time.deltaTime, Space.World);
        }

        public void SetSelectedItem(ItemComponent item)
        {
            _item = item;
            SetIsInspectingItem(false);
        }

        private void OnInspectItem()
        {
            SetIsInspectingItem(!_isInspectingItem);
        }
        private void SetIsInspectingItem(bool value)
        {
            _isInspectingItem = value;

            _targetCameraFOV = value ? CAMERA_ZOOM_FOV : CAMERA_DEFAULT_FOV;

            if (value)
                _inputService.SetInputMap(InputMapType.UI);
            else
                _inputService.SetDefaultInputMap();
        }
    }
}