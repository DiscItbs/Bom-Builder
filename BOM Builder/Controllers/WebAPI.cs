using System;
using System.Collections.Generic;
using System.Configuration;
using IQMS.Entities.Lib.Manufacturing;
using IQMS.Entities.Lib.UserDefined;
using IQMS.WebAPIClient;
using IQMS.WebAPIClient.RequestBuilder;

namespace BOM_Builder
{
    class WebAPI
    {
        Conexion conn = new Conexion();

        public IQMSServiceClient auth()
        {
            string webUser = ConfigurationSettings.AppSettings.Get("webUser");
            string webPass = ConfigurationSettings.AppSettings.Get("webPass");
            string webUrl = ConfigurationSettings.AppSettings.Get("webUrl");
            const string webPoolApplication = "IQMSWEBSITE";

            IQMSServiceClient webService = new IQMSServiceClient(webUrl, webUser, webPass, webPoolApplication);

            try
            {
                webService.Authenticate();
            }
            catch (Exception e)
            {
                var message = e.Message;
                return null;
            }

            return webService;
        }
           
        public void insertPartToBOM(int standard_id, int arinvnt_id)
        {
            IQMSServiceClient serviceClient = auth();

            string URL_INSERT_BOM = "";

            ServiceRequest request = serviceClient.NewRequest(URL_INSERT_BOM);
            request.SetHttpMethod("POST");
            request.SetDataObject(new { standardId = standard_id, arInvtId = arinvnt_id });

            var response = serviceClient.GetSuccessResult(request);
        }
      
        public InventoryItemBase createNewItemInv(InventoryItemBase item)
        {
            IQMSServiceClient serviceClient = auth();
            InventoryItemBase itemResult = new InventoryItemBase();

            string URL_CREATE_ITEMINVENTORY = "/Manufacturing/Inventory/CreateInventoryItem";

            ServiceRequest request = serviceClient.NewRequest(URL_CREATE_ITEMINVENTORY);
            request.SetHttpMethod("POST");
            request.SetDataObject(item);

            try
            {
                return itemResult = serviceClient.GetItem<InventoryItemBase>(request);
            }
            catch (Exception e)
            {
                string message = e.ToString();
            }

            return null;
        }

        public List<BomComponent> getBOMComponents(long standardID, long arInvt)
        {
            IQMSServiceClient serviceClient = auth();

            string URL_GET_BOMCOMPONENT = string.Format("/Manufacturing/BOM/BomComponentsEx/?standardId={0}&arInvtId={1}", standardID, arInvt);
            BomComponent bom = new BomComponent();
            ServiceRequest request = serviceClient.NewRequest(URL_GET_BOMCOMPONENT);//.setHeader(standardID,arInvt);
            List<BomComponent> bomPart = new List<BomComponent>();

            try
            {
                bomPart = serviceClient.GetItems<BomComponent>(request);
            }
            catch (Exception e)
            {
                string asd = e.Message;
            }

            return bomPart;
        }

        public void getUserField()
        {
            IQMSServiceClient serviceClient = auth();


            string URL_GET_BOMCOMPONENT = "/Manufacturing/BOM/UserDefinedFields/?standardId=64432&manufacturingType=GENERIC";

            ServiceRequest request = serviceClient.NewRequest(URL_GET_BOMCOMPONENT);//.setHeader(standardID,arInvt);
            request.SetHttpMethod("GET");

            //request.SetDataObject(new { standardId = 64291, manufacturingType = "GENERIC" });
            try
            {
                //List<BomPart> bomPart = serviceClient.GetItems<BomPart>(serviceClient.NewRequest(URL_GET_BOMCOMPONENT).SetHttpMethod("GET").SetDataObject(new { standardId = standardID }));
                var dd = serviceClient.GetItem<UDData>(request);
            }
            catch (Exception e)
            {
                string asd = e.Message;
            }
        }

        public void crearArtInvt(BomComponent component)
        {
            IQMSServiceClient serviceClient = auth();
            InventoryItemBase itemBase = new InventoryItemBase();

            string URL_INSERT_ITEM_INV = "/Manufacturing/Inventory/CreateInventoryItem";

            ServiceRequest request = serviceClient.NewRequest(URL_INSERT_ITEM_INV);
            request.SetHttpMethod("POST");

            itemBase.InventoryClass = component.InventoryClass;
            itemBase.EplantId = component.EPlantId;
            itemBase.ItemNumber = component.ItemNo;
            itemBase.Description = component.Descrip;
            itemBase.InactiveFlag = "N";
            itemBase.Unit = component.Unit;
            itemBase.StandardId = component.StandardId;
            itemBase.ExtDescription = component.Descrip;

            request.SetDataObject(itemBase);

            try
            {
                var response = serviceClient.GetSuccessResult(request);
            }
            catch (Exception e)
            {
                string asd = e.ToString();
            }
        }

        public void crearArtInvt(InventoryItemBase inventoryItem)
        {
            IQMSServiceClient serviceClient = auth();

            string URL_INSERT_ITEM_INV = "/Manufacturing/Inventory/CreateInventoryItem";

            ServiceRequest request = serviceClient.NewRequest(URL_INSERT_ITEM_INV);
            request.SetHttpMethod("POST");

            request.SetDataObject(inventoryItem);

            try
            {
                var response = serviceClient.GetSuccessResult(request);
            }
            catch (Exception e)
            {
                string asd = e.ToString();
            }
        }

        public BillOfMaterials createNewBom(string MfgType, string MfgNo)
        {
            IQMSServiceClient serviceClient = auth();
            string URL_INSERT_BOM = "/Manufacturing/BOM/CreateBillOfMaterials";

            ServiceRequest request = serviceClient.NewRequest(URL_INSERT_BOM);
            request.SetHttpMethod("POST");

            request.SetDataObject(new { mfgType = MfgType, mfgNo = MfgNo });

            try
            {
                BillOfMaterials bom = serviceClient.GetItem<BillOfMaterials>(request);
                return bom;
            }
            catch (Exception e)
            {
                string asd = e.ToString();
            }

            return null;
        }

        public BomPart AddPartToBOM(string arinvtID, long standardID)
        {
            IQMSServiceClient serviceClient = auth();
            string URL_INSERT_PARTTOBOM = "/Manufacturing/BOM/AddPartToBom";
            BomPart bomPart = new BomPart();
            ServiceRequest request = serviceClient.NewRequest(URL_INSERT_PARTTOBOM);
            request.SetHttpMethod("POST");

            request.SetDataObject(new { standardId = standardID, arInvtId = arinvtID });

            try
            {
                //var result = serviceClient.GetSuccessResult(request);
                bomPart = serviceClient.GetItem<BomPart>(request);
            }
            catch (Exception e)
            {
                string asd = e.ToString();
            }

            return bomPart;
        }

        public BillOfMaterialsEx getBOM(long standardID)
        {
            BillOfMaterialsEx bom = new BillOfMaterialsEx();

            IQMSServiceClient serviceClient = auth();
            string URL_GET_BOM = string.Format("/Manufacturing/BOM/BillOfMaterialEx/?standardId={0}", standardID);

            ServiceRequest request = serviceClient.NewRequest(URL_GET_BOM);
            request.SetHttpMethod("GET");

            try
            {
                bom = serviceClient.GetItem<BillOfMaterialsEx>(request);
            }
            catch (Exception e)
            {
                string asd = e.ToString();
            }

            return bom;
        }

        public void UpdateBOM(BillOfMaterials bom)
        {
            IQMSServiceClient serviceClient = auth();
            string URL_UPDATE_BOM = "/Manufacturing/BOM/UpdateBillOfMaterials";

            ServiceRequest request = serviceClient.NewRequest(URL_UPDATE_BOM);
            request.SetHttpMethod("POST");

            request.SetDataObject(bom);

            try
            {
                var result = serviceClient.GetSuccessResult(request);
            }
            catch (Exception e)
            {
                string asd = e.ToString();
            }
        }

        public void AddComponentToPart(long partno_id, long arinvt_ID, decimal part_pers)
        {
            IQMSServiceClient serviceClient = auth();
            string URL_INSERT_PARTTOBOM = "/Manufacturing/BOM/AddComponentToPart";

            ServiceRequest request = serviceClient.NewRequest(URL_INSERT_PARTTOBOM);
            request.SetHttpMethod("POST");

            request.SetDataObject(new { partnoId = partno_id, arInvtId = arinvt_ID, ptsPer = part_pers });

            try
            {
                var result = serviceClient.GetSuccessResult(request);
            }
            catch (Exception e)
            {
                string asd = e.ToString();
            }
        }
    }
}
