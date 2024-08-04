

using Microsoft.Extensions.Logging;
using Shop.Suppliers.Application.Base;
using Shop.Suppliers.Application.Dtos;
using Shop.Suppliers.Domain.Interfaces;
using Shop.Suppliers.Application.Extensions;
using Shop.Suppliers.Domain.Entities;
using Shop.Suppliers.Application.Contracts;
using System.Runtime.Versioning;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Linq;

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

        public ServicesResult<List<SuppliersDtoGetAll>> GetSuppliers()
        {
            var result = new ServicesResult<List<SuppliersDtoGetAll>>();
            try
            {
                var suppliers = this.suppliersRepository.GetAll();

                result.Result = suppliers.Select(supplier =>
                                  new SuppliersDtoGetAll()
                                 {
                                     supplierid = supplier.Id,
                                     companyname = supplier.companyname,
                                     contactname = supplier.contactname,
                                     contacttitle = supplier.contacttitle,
                                     address = supplier.address,
                                     city = supplier.city,
                                     region = supplier.region,
                                     postalcode = supplier.postalcode,
                                     country = supplier.country,
                                     phone = supplier.phone,
                                     fax = supplier.fax,
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


        public ServicesResult<SuppliersDtoRemove> RemoveSuppliers(SuppliersDtoRemove supplierDtoRemove)
        {
            ServicesResult<SuppliersDtoRemove> result = new ServicesResult<SuppliersDtoRemove>();

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
                    Id = supplierDtoRemove.supplierid,
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

        public ServicesResult<SuppliersDtoSave> SaveSuppliers(SuppliersDtoSave supplierDtoSave)
        {
            ServicesResult<SuppliersDtoSave> result = new ServicesResult<SuppliersDtoSave>();

            try
            {
                //result = supplierDtoSave.IsValidSupplier();

                if (!result.Success)
                {
                    result.Success = result.Success;
                    result.Message = result.Message;
                    return result;
                }
 
                this.suppliersRepository.Update( new Domain.Entities.Suppliers()
                {
                     /*= supplierDtoSave.supplierid,*/
                    companyname = supplierDtoSave.companyname,
                    contactname = supplierDtoSave.contactname,
                    contacttitle = supplierDtoSave.contacttitle,
                    address = supplierDtoSave.address,
                    city = supplierDtoSave.city,
                    region = supplierDtoSave.region,
                    postalcode = supplierDtoSave.postalcode,
                    country = supplierDtoSave.country,
                    phone = supplierDtoSave.phone,
                    fax = supplierDtoSave.fax,
                    
                    
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el suplidor.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<SuppliersDtoUpdate> UpdateSuppliers(SuppliersDtoUpdate suppliersDtoUpdate)
        {
            ServicesResult<SuppliersDtoUpdate> result = new ServicesResult<SuppliersDtoUpdate>();

            try
            {
                //result = supplierDtoSave.IsValidSupplier();

                if (!result.Success)
                {
                    result.Success = result.Success;
                    result.Message = result.Message;
                    return result;
                }

                this.suppliersRepository.Save(new Domain.Entities.Suppliers()
                {
                    /*= supplierDtoSave.supplierid,*/
                    companyname = suppliersDtoUpdate.companyname,
                    contactname = suppliersDtoUpdate.contactname,
                    contacttitle = suppliersDtoUpdate.contacttitle,
                    address = suppliersDtoUpdate.address,
                    city = suppliersDtoUpdate.city,
                    region = suppliersDtoUpdate.region,
                    postalcode = suppliersDtoUpdate.postalcode,
                    country = suppliersDtoUpdate.country,
                    phone = suppliersDtoUpdate.phone,
                    fax = suppliersDtoUpdate.fax,
                    modify_date = suppliersDtoUpdate.modify_date,
                    modify_user = suppliersDtoUpdate.modify_user,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el suplidor.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<SuppliersDtoGetAll> GetSuppliersById(int id)
        {
            var result = new ServicesResult<SuppliersDtoGetAll>();
            try
            {/*
                if (!result.Success)
                {
                    result.Success = result.Success;
                    result.Message = result.Message;
                    return result;
                }
*/
                var supplier = this.suppliersRepository.GetEntityById(id);

                result.Result = new SuppliersDtoGetAll()
                {
                    
                    contactname = supplier.,
                    contacttitle = supplier.contacttitle,
                    address = supplier.address,
                    city = supplier.city,
                    region = supplier.region,
                    postalcode = supplier.postalcode,
                    country = supplier.country,
                    phone = supplier.phone,
                    fax = supplier.fax,
                    creation_date = supplier.creation_date,
                    creation_user = supplier.creation_user

                };
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
