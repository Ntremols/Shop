

using Microsoft.Extensions.Logging;
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;
using Shop.Suppliers.Domain.Interfaces;
using Shop.Suppliers.Application.Extensions;
using Shop.Suppliers.Domain.Entities;
using Shop.Suppliers.Application.Contracts;

namespace Shop.Suppliers.Application.Services
{
    public class SuppliersServices : ISuppliersServices
    {
        private readonly ISuppliersRepository suppliersRepository;
        private readonly ILogger<SuppliersServices> logger;

        public SuppliersServices(ISuppliersRepository suppliersRepository, ILogger<SuppliersServices> logger)
        {
            this.suppliersRepository = suppliersRepository;
            this.logger = logger;
        }

        public ServicesResult GetSuppliers()
        {
            ServicesResult result = new ServicesResult();
            try
            {
                var suppliers = this.suppliersRepository.GetAll();

                result.Result = (from supplier in suppliers
                                 where supplier.deleted == false
                                 select new SuppliersDtoGetAll()
                                 {
                                     supplierid = supplier.Id,
                                     companyname = supplier.companyname,
                                     contactname = supplier.contactname,
                                     creation_date = supplier.creation_date,
                                     creation_user = supplier.creation_user
                                 }).OrderByDescending(cd => cd.creation_date).ToList();

                result.Success = true; // Set success to true after successful operation
                Console.WriteLine("here");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el suplidor.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
        }


        public ServicesResult RemoveSuppliers(SuppliersDtoRemove supplierDtoRemove)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                if (supplierDtoRemove is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(supplierDtoRemove)} es requerido.";
                    return result;
                }

                Domain.Entities.Suppliers supplier = new Domain.Entities.Suppliers()
                {
                    Id = supplierDtoRemove.Id,
                    deleted = supplierDtoRemove.deleted,
                    delete_date = supplierDtoRemove.delete_date,
                    delete_user = supplierDtoRemove.delete_user

                };
                this.suppliersRepository.Remove(supplier);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error moviendo el suplidor.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult SaveSuppliers(SuppliersDtoSave supplierDtoSave)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                result = supplierDtoSave.IsValidSupplier();

                if (!result.Success)
                    return result;

                Domain.Entities.Suppliers supplier = new Domain.Entities.Suppliers()
                {
                    companyname = supplierDtoSave.companyname,
                    contactname = supplierDtoSave.contactname,
                    creation_date = supplierDtoSave.creation_date,
                    creation_user = supplierDtoSave.creation_user,
                    deleted = false
                };

                this.suppliersRepository.Save(supplier);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el suplidor.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult UpdateSuppliers(SuppliersDtoUpdate suppliersDtoUpdate)
        {
            ServicesResult result = new ServicesResult();

            try
            {

                result = suppliersDtoUpdate.IsValidSupplier();

                if (!result.Success)
                    return result;


                Domain.Entities.Suppliers supplier = new Domain.Entities.Suppliers()
                {
                    Id = suppliersDtoUpdate.supplierid,
                    companyname = suppliersDtoUpdate.companyname,
                    contactname = suppliersDtoUpdate.contactname,
                    modify_date = suppliersDtoUpdate.modify_date,
                    modify_user = suppliersDtoUpdate.modify_user
                };

                this.suppliersRepository.Update(supplier);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando el suplidor.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
        }

        public ServicesResult GetSuppliersById(int id)
        {
            ServicesResult result = new ServicesResult();

            try
            {
                result.Result = (from supplier in suppliersRepository.GetAll()
                                 where supplier.Id == id
                                 && supplier.deleted == false

                                 select new SuppliersDtoGetAll()
                                 {
                                     supplierid = supplier.Id,
                                     companyname = supplier.companyname,
                                     contactname = supplier.contactname,
                                     creation_date = supplier.creation_date,
                                     creation_user = supplier.creation_user
                                 }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el suplidor.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
        }
    }
}
