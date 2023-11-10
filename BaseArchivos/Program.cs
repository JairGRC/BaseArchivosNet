using System;
using System.IO;
using System.Text;

namespace BaseArchivos
{
    class Program
    {
        public static void Model(string rutaClase, string proyect, string fileClase)
        {
            string[] ClaseBase =
            {
                "using System;",
                "using System.Collections.Generic;",
                "using System.ComponentModel.DataAnnotations.Schema;",
                "using System.Runtime.Serialization;",
                string.Format("namespace {0}Microservice.Entities.Model",proyect),
                "{",
                "      [DataContract]",
                string.Format("public class {0}Entity",fileClase),
                "{",
                "[DataMember(EmitDefaultValue =false,Name = \"cPerCodigo\")]",
                " public string cPerCodigo { get; set; }",
                "}",
                "}"
            };
            File.WriteAllLines(rutaClase, ClaseBase, Encoding.UTF8);
        }
        public static void eFilter(string EstructuraBase, string proyect, string rutaFiltro, string Filter)
        {
            string[] FilterBase =
            {
                EstructuraBase,
                string.Format("namespace {0}Microservice.Entities.Filter",proyect),
                "{",
                 string.Format("public class {0}",Filter),
                 "{",
                 "\tpublic string cPerCodigo { get; set; }",
                 "}",
                 "}"
            };
            File.WriteAllLines(rutaFiltro, FilterBase, Encoding.UTF8);
        }
        public static void eFilterType(string EstructuraBase, string proyect, string fileClase, string rutaFilterType)
        {
            string[] FilterTypeBase =
            {
                EstructuraBase,
                string.Format("namespace {0}Microservice.Entities.Filter",proyect),
                "{",
                string.Format("public enum {0}FilterItemType : byte",fileClase),
                "{",
                "Undefined,",
                "BycPerCodigo",
                "}",
                string.Format("public enum {0}FilterListType : byte",fileClase),
                "{",
                    "Undefined,\nByList,\nByPagination,\nByCabecera,\nByDependencia",
                "}",
                "}"
            };
            File.WriteAllLines(rutaFilterType, FilterTypeBase, Encoding.UTF8);
        }
        public static void eRequest(string EstructuraBase, string proyect, string fileClase, string RutaRequest)
        {
            string[] RequestBase =
            {
                EstructuraBase,
                string.Format("using {0}Microservice.Entities.Filter;",proyect),
                string.Format("using {0}Microservice.Entities.Model;",proyect),
                string.Format("namespace {0}Microservice.Entities.Request",proyect),
                "{",
                string.Format("public class {0}Request : OperationRequest<{0}Entity>",fileClase),
                "{",
                "}",
                string.Format("public class {0}ItemRequest : FilterItemRequest<{0}Filter, {0}FilterItemType>",fileClase),
                "{",
                "}",
                string.Format("public class {0}LstItemRequest : FilterLstItemRequest<{0}Filter, {0}FilterListType>",fileClase),
                "{",
                "}",
                "}",
            };
            File.WriteAllLines(RutaRequest, RequestBase, Encoding.UTF8);
        }
        public static void eResponse(string EstructuraBase, string proyect, string fileClase, string RutaResponse)
        {
            string[] ResponseBase =
            {
                string.Format("using {0}Microservice.Entities.Request;",proyect),
                string.Format("using {0}Microservice.Entities.Model;",proyect),
                EstructuraBase,
                string.Format("namespace {0}Microservice.Entities.Response",proyect),
                "{",
                string.Format("public class {0}Response : ItemResponse<bool>",fileClase),
                "{",
                "}",
                string.Format("public class {0}ItemResponse : ItemResponse<{0}Entity>",fileClase),
                "{",
                "}",
                string.Format("public class {0}LstItemResponse : LstItemResponse<{0}Entity>",fileClase),
                 "{",
                "}",
                "}",
            };
            File.WriteAllLines(RutaResponse, ResponseBase, Encoding.UTF8);
        }
        public static void IRepositorio(string EstructuraBase, string proyect, string fileClase, string RutaIRepository)
        {
            string[] RepositoryBase =
            {
                string.Format("using {0}Microservice.Entities.Filter;",proyect),
                string.Format("using {0}Microservice.Entities.Model;",proyect),
                string.Format("using {0}Microservice.Repository;",proyect),
                string.Format("using {0}Microservice.Entities;",proyect),
                string.Format("using {0}Microservice.Entities.Request;",proyect),
                EstructuraBase,
                string.Format("namespace {0}Microservice.Repository",proyect),
                "{",
                string.Format("public interface I{0}Repository: IGenericRepository<{0}Entity>",fileClase),
                "{",
                //string.Format("long Insert({0}Entity item);",fileClase),
                string.Format("Task<{0}Entity> GetItem({0}Filter filter, {0}FilterItemType filterType);",fileClase),
                string.Format("Task<IEnumerable<{0}Entity>> GetLstItem({0}Filter filter, {0}FilterListType filterType, Pagination pagination);",fileClase),
                "}",
                "}"
            };
            File.WriteAllLines(RutaIRepository, RepositoryBase, Encoding.UTF8);
        }

        public static void Infraestructura(string EstructuraBase, string proyect, string fileClase, string RutaInfraestructure)
        {
            string[] InfraestructureBase =
            {
                "using Dapper;",
                "using System.Composition;",
                string.Format("using {0}Microservice.Entities;",proyect),
                string.Format("using {0}Microservice.Entities.Filter;",proyect),
                string.Format("using {0}Microservice.Entities.Model;",proyect),
                string.Format("using {0}Microservice.Repository;",proyect),
            EstructuraBase,
                string.Format("namespace {0}Microservice.Infraestructure",proyect),
                 "{",
                string.Format("[Export(typeof(I{0}Repository))]",fileClase),
                string.Format("public class {0}Repository: BaseRepository, I{0}Repository",fileClase),
                "{",
                "#region Constructor \n[ImportingConstructor]\n",
                string.Format("public {0}Repository(IConnectionFactory cn) : base(cn)",fileClase),
                "{\n",
                "}",
                "#endregion\n#region Public Methods",

                 string.Format("public async Task<long> Insert({0}Entity item)",fileClase),
                "{\n throw new NotImplementedException();",
                "//long id = 0;",
                "//var query = \"USP_Pertelefono_Create\";",
                "//var param = new DynamicParameters();",
                "//param.Add(\"@MP_cPerCodigo\", item.cPerCodigo, System.Data.DbType.String);",
                "//param.Add(\"@MP_nPerTelTipo\", item.nPerTelTipo, System.Data.DbType.Int32);",
                "//param.Add(\"@MP_cPerTelNumero\", item.cPerTelNumero, System.Data.DbType.String);",
                "//param.Add(\"@MP_nPerTelStatus\", item.nPerTelStatus, System.Data.DbType.Int32);",
                "//param.Add(\"@MP_dPerTelFecRegistro\", item.dPerTelFecRegistro, System.Data.DbType.DateTime);",
                "//id = (long)SqlMapper.Execute(this._connectionFactory.GetConnection, query,param, commandType: System.Data.CommandType.StoredProcedure);",
                "//return id;",
                " \n}",
                string.Format("public async Task<bool> Update({0}Entity item)",fileClase),
                "{\n throw new NotImplementedException();",
                "//var query = \"USP_Pertelefono_Update\";",
                "//var param = new DynamicParameters();",
                "//param.Add(\"@MP_cPerCodigo\", item.cPerCodigo, System.Data.DbType.String);",
                "//param.Add(\"@MP_nPerTelTipo\", item.nPerTelTipo, System.Data.DbType.Int32);",
                "//param.Add(\"@MP_cPerTelNumero\", item.cPerTelNumero, System.Data.DbType.String);",
                "//param.Add(\"@PerTelNuevoNumero\", item.cPerTelNumeroNuevo, System.Data.DbType.String);",
                "//param.Add(\"@MP_nPerTelStatus\", item.nPerTelStatus, System.Data.DbType.Int32);",
                "//param.Add(\"@MP_dPerTelFecRegistro\", item.dPerTelFecRegistro, System.Data.DbType.DateTime);",
                "//return (int)SqlMapper.Execute(this._connectionFactory.GetConnection,query, param, commandType: System.Data.CommandType.StoredProcedure) > 0;",
                "}",

                "public async Task<bool> Delete(long id)\n{\nthrow new NotImplementedException();\n}",

                "\npublic async  Task<bool> Delete(string id)\n{",
                "\n throw new NotImplementedException();",
                "//bool exito = false;",
                "//var regAfectados = 0;",
                "//var query = \"USP_Persona_Delete\";",
                "//var param = new DynamicParameters();",
                "//param.Add(\"@MP_cPerCodigo\", id);",
                "// regAfectados = (int)SqlMapper.Execute(this._connectionFactory.GetConnection,query, param, commandType: System.Data.CommandType.StoredProcedure);",
                "//exito = regAfectados > 0;",
                "//return exito;",
                "\n}",

                string.Format("public async Task<{0}Entity> GetItem({0}Filter filter, {0}FilterItemType filterType)",fileClase),
                "{",
                string.Format("{0}Entity itemfound = null;",fileClase),
                "switch (filterType)",
                "{",
                string.Format("case {0}FilterItemType.Undefined:",fileClase),
                "break;",
                string.Format("case {0}FilterItemType.BycPerCodigo:",fileClase),
                "itemfound = await this.obtenerDatosPersonales(filter);",
                "break;",
                "}",
                "return itemfound;",
                "}",
                string.Format("public async Task<IEnumerable<{0}Entity>> GetLstItem({0}Filter filter, {0}FilterListType filterType, Pagination pagination)",fileClase),
                "{",
                "//throw new NotImplementedException();",
                string.Format("IEnumerable<{0}Entity> lstItemFound = new List<{0}Entity>();",fileClase),
                "switch (filterType)",
                "{",
                string.Format("case {0}FilterListType.ByList:",fileClase),
                "//        lstItemFound = await this.getByList();",
                "        break;",
                "//    case PertelefonoFilterListType.BycPerCodigo:",
                "//        lstItemFound =await  this.BycPerCodigo(filter);",
                "//        break;",
                "    default:",
                "       break;",
                "}",
                "return lstItemFound;",
                "}",

                "#endregion\n#region Private Methods",
                string.Format("private async  Task<{0}Entity> obtenerDatosPersonales({0}Filter filter)",fileClase),
                "{",
                string.Format("{0}Entity itemfound = null;",fileClase),
                "var query = \"\";",
                "var param = new DynamicParameters();",
                string.Format("itemfound = await SqlMapper.QueryFirstOrDefaultAsync<{0}Entity>(this._connectionFactory.GetConnection, query, param,commandType: System.Data.CommandType.StoredProcedure);",fileClase),
                "return itemfound;",
                 "}",
                "//private async Task<IEnumerable<PertelefonoEntity>> getByList()",
                "//{",
                "//    IEnumerable<PertelefonoEntity> lstfound = new List<PertelefonoEntity>();",
                "//    var query = \"USP_Pertelefono_Get\";",
                "//    var param = new DynamicParameters();",
                "//    param.Add(\"@MP_cPerCodigo\", null);",
                "//    lstfound = await SqlMapper.QueryAsync<PertelefonoEntity>(this._connectionFactory.GetConnection, query, param,",
                "//        commandType: System.Data.CommandType.StoredProcedure);",
                "//    return lstfound;",
                "//}",
                 "#endregion",
                 "}",
                "}"
            };
            File.WriteAllLines(RutaInfraestructure, InfraestructureBase, Encoding.UTF8);
        }
        public static void EDomain(string EstructuraBase, string proyect, string fileClase, string RutaDomain)
        {

            string[] DomainBase =
            {
                string.Format("using {0}Microservice.Entities;",proyect),
                string.Format("using {0}Microservice.Entities.Filter;",proyect),
                string.Format("using {0}Microservice.Entities.Model;",proyect),
                string.Format("using {0}Microservice.Entities.Request;",proyect),
                string.Format("using {0}Microservice.Entities.Response;",proyect),
                string.Format("using {0}Microservice.Exceptions;",proyect),
                string.Format("using {0}Microservice.Repository;",proyect),
                EstructuraBase,
                 "using System.Composition;",
                 "using System.Transactions;",
                 "using Util;",
                 string.Format("namespace {0}Microservice.Domain",proyect),
                 "{",
                 string.Format("public class {0}Domain",fileClase),
                 "{",
                 "#region MEF\n[Import]",
                 string.Format("private I{0}Repository _{0}Repository ",fileClase)+"{ get; set; }",
                 "#endregion\n#region Constructor ",
                 string.Format("public {0}Domain()",fileClase),
                 "{",
                 string.Format(" _{0}Repository = MEFContainer.Container.GetExport<I{0}Repository>();",fileClase),
                 "}",
                 "#endregion\n#region Method Publics ",
                 string.Format(" public async Task<Result<bool>> Create{0}({0}Entity {0})",fileClase),
                 "{\n throw new NotImplementedException(); ",
                "//     long id = 0;",
                "//bool exito = false;",
                "//using (TransactionScope tx = new TransactionScope())",
                "//{",
                "//    id = _PernameRepository.Insert(Pername);",
                "//    if (id == 0)",
                "//    {",
                "//        throw new FailAddPernameHeaderException();",
                "//    }",
                "//    else",
                "//    {",
                "//        exito = true;",
                "//    }",
                "//    if (exito) tx.Complete();",
                "//}",
                "//return id > 0;",
                "\n}",
                 string.Format(" public async Task<Result<bool>> Edit{0}({0}Entity {0})",fileClase),
                 "{\n throw new NotImplementedException(); ",
                "//     using (TransactionScope tx = new TransactionScope())",
                "//{",
                "//    if (_PernameRepository.Update(Pername))",
                "//    {",
                "//        tx.Complete();",
                "//        return true;",
                "//    }",
                "//}",
                "//return false;",
                "\n}",
                 string.Format(" public async Task<Result<bool>> Delete{0}(string cPerCodigo)",fileClase),
                 "{\n throw new NotImplementedException();",
                    "// bool exito = false;",
                    "//exito = _PernameRepository.delete(nConstcodigo, dPerFecEfectiva);",
                    "//return exito;",
                " \n}",
                 string.Format("public async Task<Result<{0}Entity>> GetByItem({0}Filter filter, {0}FilterItemType filterType)",fileClase),
                 "{",
                 string.Format("Result<{0}Entity> {0} = new Result<{0}Entity>();",fileClase),
                 string.Format("{0}.Data = await _{0}Repository.GetItem(filter,filterType);",fileClase),
                 //string.Format("new {0}Filter()",fileClase),
                 //"{",
                 //"cPerCodigo = CperCodigo",
                 //"},",
                 //string.Format(" {0}FilterItemType.BycPerCodigo);",fileClase),
                 string.Format("return await Task.FromResult({0});",fileClase),
                 "}",
                 string.Format("public async Task<ListResult<{0}Entity>> GetByList({0}Filter filter,{0}FilterListType filterType, Pagination pagination)",fileClase),
                 "{",
                 string.Format("ListResult<{0}Entity> lst = new ListResult<{0}Entity>();",fileClase),
                 string.Format("lst.Data =await  _{0}Repository.GetLstItem(filter, filterType, pagination);",fileClase),
                 "return lst;",
                 "}",
                 "#endregion",
                 "}",
                 "}"
            };
            File.WriteAllLines(RutaDomain, DomainBase, Encoding.UTF8);
        }
        public static void eService(string EstructuraBase, string proyect, string fileClase, string RutaService)
        {
            string[] ServiceBase =
            {
                 string.Format("using {0}Microservice.Entities;",proyect),
                string.Format("using {0}Microservice.Entities.Filter;",proyect),
                string.Format("using {0}Microservice.Entities.Model;",proyect),
                string.Format("using {0}Microservice.Entities.Request;",proyect),
                string.Format("using {0}Microservice.Entities.Response;",proyect),
                string.Format("using {0}Microservice.Exceptions;",proyect),
                string.Format("using {0}Microservice.Domain;",proyect),
                EstructuraBase,
                string.Format("namespace {0}Microservice.Service",proyect),
                "{",
                string.Format("public class {0}Service",fileClase),
                "{",
                "#region Public Methods",
                string.Format("public async Task<{0}Response> Execute({0}Request request)",fileClase),
                "{",
                string.Format("{0}Response response = new {0}Response();",fileClase),
                "response.InitializeResponse(request);",
                "try",
                "{",
                "if (response.LstError.Count == 0)",
                "{",
                "switch (request.Operation)",
                "{",
                 "case Operation.Undefined:\nbreak;",
                 "case Operation.Add:",
                 string.Format("response.Item = await new {0}Domain().Create{0}(request.Item);",fileClase),
                 "break;",
                 "case Operation.Edit:",
                 string.Format("response.Item = await new {0}Domain().Edit{0}(request.Item);",fileClase),
                 "break;",
                "//case Operation.Delete:",
                       string.Format("//response.Item = await new {0}Domain().Delete{0}(Request.Item.cPerCodigo)", fileClase),
                 "//break;",
            "default:\nbreak;",
                 "}",
                 "response.IsSuccess = true;",
                 "}",
                 "}",
                 "catch (CustomException ex)\n{\nresponse.LstError.AddRange(ex.EResponse);\n}\ncatch (Exception ex)\n{\nresponse.LstError.Add(new EResponse() { cDescripcion = ex.Message});\n}\nreturn response;",
                 "}",
                 string.Format("public async Task<{0}ItemResponse> Get{0}({0}ItemRequest request)",fileClase),
                 "{",
                 string.Format("{0}ItemResponse response = new {0}ItemResponse();",fileClase),
                 "response.InitializeResponse(request);",
                "try",
                "{",
                "if (response.LstError.Count == 0)",
                "{",
                "switch (request.FilterType)\n{",
                string.Format("case {0}FilterItemType.Undefined:",fileClase),
                "break;",
                string.Format("case {0}FilterItemType.BycPerCodigo:",fileClase),
                string.Format("response.Item = await new {0}Domain().GetByItem(request.Filter,request.FilterType);",fileClase),
                "break;",
                "default:\nbreak;",
                "}",
                "response.IsSuccess = true;",
                "}",
                "}",
                "catch (CustomException ex)\n{\nresponse.LstError.AddRange(ex.EResponse);\n}\ncatch (Exception ex)\n{\nresponse.LstError.Add(new EResponse() { cDescripcion = ex.Message});\n}\nreturn response;",
                "}",
                string.Format("public async Task<{0}LstItemResponse> GetLst{0}({0}LstItemRequest request)",fileClase),
                "{",
                string.Format("{0}LstItemResponse response = new {0}LstItemResponse();",fileClase),
                "response.InitializeResponse(request);",
                "try",
                "{",
                "if (response.LstError.Count == 0)",
                "{",
                "switch (request.FilterType)\n{",
                string.Format("case {0}FilterListType.Undefined:",fileClase),
                "break;",
                string.Format("case {0}FilterListType.ByList:",fileClase),
                string.Format("response.LstItem = await new {0}Domain().GetByList(request.Filter,request.FilterType, request.Pagination); ",fileClase),
                "break;",
                "default:\nbreak;",
                "}",
                "response.IsSuccess = true;",
                "}",
                "}",
                "catch (CustomException ex)\n{\nresponse.LstError.AddRange(ex.EResponse);\n}\ncatch (Exception ex)\n{\nresponse.LstError.Add(new EResponse() { cDescripcion = ex.Message});\n}\nreturn response;",
                "}",
                "#endregion",
                "}",
                "}"
        };
            File.WriteAllLines(RutaService, ServiceBase, Encoding.UTF8);
        }
        static void Main(string[] args)
        {
            var Direccion = Directory.GetCurrentDirectory();
            Console.WriteLine("──────────▄▄▄▄▄▄▄▄▄──────────");
            Console.WriteLine("────▄▄▄▀▀▀▀────────▀▀▄▄──────");
            Console.WriteLine("──▄▀───────────────────▀▄────");
            Console.WriteLine("─█───────────────────▄▀▀▀▀▀█▄______________________███████████");
            Console.WriteLine("█▀───────────────────█───▄███__________________________██");
            Console.WriteLine("█─────▄▀▀██▀▄────────█▄▄▄▄▄▄█__________________________██");
            Console.WriteLine("█────█──▀██▀─█─────────────█___________________________██");
            Console.WriteLine("█────▀▄─────▄▀────────────█─______________________██████");
            Console.WriteLine("█▄─────▀▀▀▀▀──█▀█▀█▀█▀█──▄▀──");
            Console.WriteLine("──█───────────▀─▀─▀─▀─▀▄▀────");
            Console.WriteLine("───▀▀▀▄────────▄▄▄▄▄▄▀▀──────");
            Console.WriteLine("────▄▀────────▀──▄▀──────────");
            Console.WriteLine("─▄▀───────█──────█──▄▀▀▀█▀▀▄─");
            Console.WriteLine("─█────█▄▄█▀▀▀▄───█▀▀──▀▀▀──█─");
            Console.WriteLine("█────────────█───█─▄▄▄────█──");
            Console.WriteLine("█──▀▀▀▀▀▄▄▄▄▄▀────▀▄──▀▀▀▀───");
            Console.WriteLine("█──▀▀▀▀▀▄▄▄▄▄▀────▀▄──▀▀▀▀───");
            Console.WriteLine("VersionV.2 Item_y_Advertencias");
            Console.WriteLine("Ingresa nombre del Proyecto:");
            string proyect = Console.ReadLine();
            Console.WriteLine("Ingresa nombre de la clase:");
            string fileClase = Console.ReadLine();
            string namefile = fileClase + "Entity.cs";
            string rutaProyectoEntities = Direccion + "\\" + string.Format("{0}Microservice.Entities", proyect);

            string DireccionModel = rutaProyectoEntities + "\\Model\\";
            string rutaClase = DireccionModel + namefile;

            string EstructuraBase = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\n";


            string DireccionFilter = rutaProyectoEntities + "\\Filter\\";
            string DireccionRequest = rutaProyectoEntities + "\\Request\\";
            string DireccionResponse = rutaProyectoEntities + "\\Response\\";


            string Filter = fileClase + "Filter";
            string FilterType = fileClase + "FilterType";
            //string rutaFiltro = Direccion + "\\Filter\\" + Filter + ".cs";
            string rutaFiltroEntitie = DireccionFilter + Filter + ".cs";
            string rutaFiltroTypeEntitie = DireccionFilter + FilterType + ".cs";
            //string rutaFilterType = Direccion + "\\Filter\\" + FilterType + ".cs";

            //Directory.CreateDirectory("Request");
            string fileRequest = fileClase + "Request";
            string RutaRequest = DireccionRequest + fileRequest + ".cs";


            string fileResponse = fileClase + "Response";
            string RutaResponse = DireccionResponse + fileResponse + ".cs";

            // CREACION DE FILTRO PARA API 
            if (Directory.Exists(rutaProyectoEntities))
            {
                //Creando Parte Modelo
                if (Directory.Exists(DireccionModel))
                {
                    Model(rutaClase, proyect, fileClase);
                }
                else
                {
                    Directory.CreateDirectory(DireccionModel);
                    Model(rutaClase, proyect, fileClase);
                }
                //Creando Parte Filter
                if (Directory.Exists(DireccionFilter))
                {
                    eFilter(EstructuraBase, proyect, rutaFiltroEntitie, Filter);
                    eFilterType(EstructuraBase, proyect, fileClase, rutaFiltroTypeEntitie);
                }
                else
                {
                    Directory.CreateDirectory(DireccionFilter);
                    eFilter(EstructuraBase, proyect, rutaFiltroEntitie, Filter);
                    eFilterType(EstructuraBase, proyect, fileClase, rutaFiltroTypeEntitie);
                }
                // Creando Parte Request 
                if (Directory.Exists(DireccionRequest))
                {
                    eRequest(EstructuraBase, proyect, fileClase, RutaRequest);
                }
                else
                {
                    Directory.CreateDirectory(DireccionRequest);
                    eRequest(EstructuraBase, proyect, fileClase, RutaRequest);
                }

                // Creando Parte Response
                if (Directory.Exists(DireccionResponse))
                {
                    eResponse(EstructuraBase, proyect, fileClase, RutaResponse);
                }
                else
                {
                    Directory.CreateDirectory(DireccionResponse);
                    eResponse(EstructuraBase, proyect, fileClase, RutaResponse);
                }
            }



            string rutaProyectoRepository = Direccion + "\\" + string.Format("{0}Microservice.Repository", proyect);

            string fileIRepository = "I" + fileClase + "Repository";
            string direccionRepository = rutaProyectoRepository + "\\";
            string RutaIRepository = direccionRepository + fileIRepository + ".cs";

            if (Directory.Exists(rutaProyectoRepository))
            {
                //Creando Pare Interface Repositorio 
                IRepositorio(EstructuraBase, proyect, fileClase, RutaIRepository);
            }



            // Creando Parte Infraestructura

            string rutaProyectoInfraestructura = Direccion + "\\" + string.Format("{0}Microservice.Infraestructure", proyect);


            string fileInfraestructure = fileClase + "Repository";
            string direccionInfraestructure = rutaProyectoInfraestructura + "\\";
            string RutaInfraestructure = direccionInfraestructure + fileInfraestructure + ".cs";

            if (Directory.Exists(rutaProyectoInfraestructura))
            {
                Infraestructura(EstructuraBase, proyect, fileClase, RutaInfraestructure);
            }


            // Creando Parte Dominio
            string rutaProyectoDomain = Direccion + "\\" + string.Format("{0}Microservice.Domain", proyect);

            string fileDomain = fileClase + "Domain";
            string direccionDomain = rutaProyectoDomain + "\\";
            string RutaDomain = direccionDomain + fileDomain + ".cs";

            if (Directory.Exists(rutaProyectoDomain))
            {
                EDomain(EstructuraBase, proyect, fileClase, RutaDomain);
            }


            // Creando Parte Service 
            string RutaProyectoService = Direccion + "\\" + string.Format("{0}Microservice.Service", proyect);
            string fileService = fileClase + "Service";
            string direccionService = RutaProyectoService + "\\";
            string RutaService = direccionService + fileService + ".cs";
            string fileRequestValidator = fileClase + "_RequestValidator";

            string RutaValidator = direccionService +  fileRequestValidator + ".cs";

            if (Directory.Exists(RutaProyectoService))
            {
                eService(EstructuraBase, proyect, fileClase, RutaService);
                eServiceValidor(EstructuraBase, proyect, fileClase, RutaValidator);
            }

        }
        public static void eServiceValidor(string EstructuraBase, string proyect, string fileClase, string RutaValidator)
        {
            string[] validatorBase =
            {
                string.Format("using {0}Microservice.Entities.Request;",proyect),
                string.Format("using {0}Microservice.Entities.Response;",proyect),
                EstructuraBase,
                string.Format("namespace {0}Microservice.Service",proyect),
                "{",
                string.Format("public static class {0}_RequestValidator",fileClase),
                "{",
                //"#region Validate ",
                //string.Format("public static void ValidateRequest(this {0}Response response, {0}Request request)",fileClase),
                //"{",
                //"if (request.Item == null)",
                //"{",
                //"response.LstError.Add(\"Se requiere la entidad "+ fileClase+"\");",
                //"}",
                //"if (string.IsNullOrEmpty(request.ServerName))",
                //"{",
                //"response.LstError.Add(\"No se identifico el servidor de origen para la solicitud\");",
                //"}",
                //"if (string.IsNullOrEmpty(request.UserName))",
                //"{",
                //" response.LstError.Add(\"No se identifico el usuario que realizo la solicitud\");",
                //"}",
                //"}",
                //"#endregion",
                "#region Initialize",
                string.Format("public static void InitializeResponse(this {0}Response response, {0}Request request)",fileClase),
                "{",
                "response.Ticket = request.Ticket;",
                "response.ServerName = request.ServerName;",
                "response.UserName = request.UserName;",
                "}",
                string.Format("public static void InitializeResponse(this {0}ItemResponse response, {0}ItemRequest request)",fileClase),
                "{",
                "response.Ticket = request.Ticket;",
                "response.ServerName = request.ServerName;",
                "response.UserName = request.UserName;",
                "}",
                string.Format("public static void InitializeResponse(this {0}LstItemResponse response, {0}LstItemRequest request)",fileClase),
                "{",
                "response.Ticket = request.Ticket;",
                "response.ServerName = request.ServerName;",
                "response.UserName = request.UserName;",
                "}",
                "#endregion",
                "}",
                "}"
            };
            File.WriteAllLines(RutaValidator, validatorBase, Encoding.UTF8);
        }


    }
}
