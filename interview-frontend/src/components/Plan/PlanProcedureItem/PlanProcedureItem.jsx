import React, { useState } from "react";
import ReactSelect from "react-select";
import { assignUserToPlanProcedure } from "../../../api/api";

const PlanProcedureItem = ({ procedure, users }) => {
  const [selectedUsers, setSelectedUsers] = useState([]);

  const handleAssignUserToProcedure = async (selectedOptions) => {
    setSelectedUsers(selectedOptions);
    const userIds = selectedOptions.map((user) => user.value);

    for (const userId of userIds) {
      try {
        await assignUserToPlanProcedure(procedure.id, userId); // Ensure 'procedure.id' is correct
        console.log(
          `User ${userId} assigned to procedure ${procedure.procedureTitle}`
        );
      } catch (error) {
        console.error(`Failed to assign user ${userId} to procedure:`, error);
      }
    }
  };

  return (
    <div className="py-2">
      <div>{procedure.procedureTitle}</div>

      <ReactSelect
        className="mt-2"
        placeholder="Select User to Assign"
        isMulti={true}
        options={users}
        value={selectedUsers}
        onChange={(e) => handleAssignUserToProcedure(e)}
      />
    </div>
  );
};

export default PlanProcedureItem;
