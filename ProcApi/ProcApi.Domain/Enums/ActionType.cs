namespace ProcApi.Domain.Enums;

public enum ActionType
{
    SaveAsDraft = 1,
    Submit,
    Approve,
    Return,
    Reject,
    Cancel,
    Revision,
    KeyUserReturn,
    KeyUserCancel
}