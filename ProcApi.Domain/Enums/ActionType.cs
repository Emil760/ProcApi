namespace ProcApi.Domain.Enums;

public enum ActionType
{
    SaveAsDraft = 1,
    Submit,
    Approve,
    Return,
    Reject,
    Revision,
    KeyUserReturn,
    KeyUserCancel
}