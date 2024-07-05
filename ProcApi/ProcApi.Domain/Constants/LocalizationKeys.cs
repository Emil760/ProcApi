namespace ProcApi.Domain.Constants
{
    public static class LocalizationKeys
    {
        public const string USER_NOT_FOUND = "UserNotFound";
        public const string WRONG_PASSWORD = "WrongPassword";
        public const string ROLE_NOT_FOUND = "RoleNotFound";
        public const string USER_ALREDY_HAS_ROLE = "UserAlreadyHasRole";
        public const string DASHBOARD_NOT_FOUND = "DashboardNotFound";
        public const string USER_ALREADY_EXISTS = "UserAlreadyExists";
        public const string USER_CAN_PERFORME_ACTION = "UserCantPerformAction";
        public const string USER_NOT_FOUND_OR_NOT_IN_ROLE = "UserNotFoundOrNotInRole";
        public const string USER_HAS_NOT_ROLE_FOR_OPERATION = "UserHasNoRoleForOperation";
        public const string USER_IS_NOT_ADMIN = "UserIsNotAdmin";
        
        public const string USER_NOT_FOUND_IN_GROUP = "UserNotFoundInGroup";
        public const string CHAT_NOT_FOUND = "ChatNotFound";
        
        public const string DOCUMENT_NOT_FOUND = "DocumentNotFound";
        public const string CANT_CHANGE_NON_DRAFT_DOCUMENT = "CantChangeNonDraftDocument";
        public const string ACTION_ALREADY_PERFORMED = "ActionAlreadyPerformed";
        public const string DOCUMENT_IS_NOT_APPROVED = "DocumentIsNotApproved";

        public const string USER_ALREADY_HAS_DEPARTMENT = "UserAlreadyHasDepartment";
        public const string USER_NOT_BELONGS_TO_DEPARTMENT = "UserDontBelongToDepartment";
        public const string DEPARTMENT_ALREADY_EXISTS = "DepartmentNameAlreadyExists";
        public const string DEPARTMENT_NOT_FOUND = "DepartmentNotFound";
        
        public const string ITEM_NOT_FOUND = "ItemNotFound";
        public const string ITEM_COUNT_EXTENDED = "ItemCountExtended";
        public const string ITEM_ALREADY_USED = "ItemAlreadyUsed";
        public const string CATEGORY_NAME_ALREADY_EXISTS = "CategoryNameAlreadyUsed";
        
        public const string UNIT_OF_MEASURE_ALREADY_EXISTS = "UnitOfMeasureAlreadyExists";
        public const string UNIT_OF_MEASURE_NAME_ALREADY_EXISTS = "UnitOfMeasureAlreadyExistsByName";
        public const string UNIT_OF_MEASURE_NOT_FOUND = "UnitOfMeasureNotFound";
        public const string CANT_USE_DECIMAL_FOR_UNIT_OF_MEASURE = "CantUseDecimalForUnitOfMeasure";
        public const string UNIT_MEASURE_RULE_NOT_FOUND = "UnitOfMeasureRuleNotFound";
        public const string UNIT_MEASURE_RULE_IS_NOT_ACTIVE = "UnitOfMeasureRuleIsNotActive";
        public const string QUANTITY_MUST_BE_INTEGER = "QuantityMustBeInteger";
        
        public const string MATERIAL_NOT_FOUND = "MaterialNotFound";
        public const string CATEGORY_NOT_FOUND = "CategoryNotFound";
        public const string MANTERIAL_NAME_ALREDY_EXISTS = "MaterialNameAlreadyExists";
        public const string MATERIAL_CODE_ALREADY_EXISTS = "MaterialCodeAlreadyExists";
        
        public const string SUPPLIER_NOT_FOUND = "SupplierNotFound";
        public const string SUPPLIER_NAME_ALREADY_EXISTS = "SupplierNameAlreadyExists";
        public const string SUPPLIER_TAX_ID_ALREADY_EXISTS = "SupplierTaxIdAlreadyExists";
        
        public const string EMPTY_ITEMS = "EmptyItems";
        
        public static string ANNUAL_PROCUREMENT_ALREADY_EXISTS = "AnnualProcurementAlreadyExists";
        public static string ANNUAL_PROCUREMENT_NOT_FOUND = "AnnualProcurementNotFound";
        public static string ACTIVE_ANNUAL_PROCUREMENT_ALREADY_EXISTS = "ActiveAnnualProcurementAlreadyExists";

        public static string PROJECT_NOT_FOUND = "ProjectNotFound";
        public static string PROJECT_NAME_ALREADY_EXISTS = "ProjectNameAlreadyExists";

        public static string DROP_DOWN_ITEM_NAME_ALREADY_EXISTS = "DropDownItemNameAlreadyExists";
        public static string DROP_DOWN_SOURCE_NAME_ALREADY_EXISTS = "DropDownSourceNameAlreadyExists";
        public static string DROP_DOWN_SOURCE_NOT_FOUND = "DropDownSourceNotFound";
        public static string DROP_DOWN_ITEM_SOURCE_NOT_FOUND = "DropDownItemNotFound";
    }
}
