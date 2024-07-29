

using Microsoft.Extensions.Logging;
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;
using Shop.Suppliers.Domain.Interfaces;
using Shop.Suppliers.Application.Extensions;
using Shop.Suppliers.Domain.Entities;
using Shop.Suppliers.Application.Contracts;

namespace Shop.Suppliers.Application.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository suppliersRepository;
        private readonly ILogger<SuppliersService> logger;

        public SuppliersService(ISuppliersRepository suppliersRepository, ILogger<SuppliersService> logger)
        {
            this.suppliersRepository = suppliersRepository;
            this.logger = logger;
        }

        public ServiceResult GetSuppliers()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var suppliers = this.suppliersRepository.GetAll();

                result.Result = (from supplier in suppliersRepository.GetAll()
                                 where supplier.Deleted == false
                                 select new SuppliersDtoGetAll()
                                 {
                                     SupplierId = supplier.Id,
                                     CompanyName= supplier.CompanyName,
                                     ContactName = supplier.ContactName,
                                     CreationDate = supplier.CreationDate,
                                     CreationUser = supplier.CreationUser
                                 }).OrderByDescending(cd => cd.CreationDate).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el suplidor.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;

        }

        public ServiceResult RemoveSuppliers(SuppliersDtoRemove supplierDtoRemove)
        {
            ServiceResult result = new ServiceResult();

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
                    Deleted = supplierDtoRemove.Deleted,
                    DeleteDate = supplierDtoRemove.DeleteDate,
                    DeleteUser = supplierDtoRemove.DeleteUser

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

        public ServiceResult SaveSuppliers(SuppliersDtoSave supplierDtoSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = supplierDtoSave.IsValidSupplier();

                if (!result.Success)
                    return result;

                Domain.Entities.Suppliers supplier = new Domain.Entities.Suppliers()
                {
                    CompanyName = supplierDtoSave.CompanyName,
                    ContactName = supplierDtoSave.ContactName,
                    CreationDate = supplierDtoSave.CreationDate,
                    CreationUser = supplierDtoSave.CreationUser,
                    Deleted = false
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

        public ServiceResult UpdateSuppliers(SuppliersDtoUpdate suppliersDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result = suppliersDtoUpdate.IsValidSupplier();

                if (!result.Success)
                    return result;


                Domain.Entities.Suppliers supplier = new Domain.Entities.Suppliers()
                {
                    Id = suppliersDtoUpdate.SupplierId,
                    CompanyName = suppliersDtoUpdate.CompanyName,
                    ContactName = suppliersDtoUpdate.ContactName,
                    ModifyDate = suppliersDtoUpdate.ModifyDate,
                    ModifyUser = suppliersDtoUpdate.ModifyUser
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

        public ServiceResult GetSuppliersById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Result = (from supplier in suppliersRepository.GetAll()
                                 where supplier.Id == id
                                 && supplier.Deleted == false

                                 select new SuppliersDtoGetAll()
                                 {
                                     SupplierId = supplier.Id,
                                     CompanyName = supplier.CompanyName,
                                     ContactName = supplier.ContactName,
                                     CreationDate = supplier.CreationDate,
                                     CreationUser = supplier.CreationUser
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
