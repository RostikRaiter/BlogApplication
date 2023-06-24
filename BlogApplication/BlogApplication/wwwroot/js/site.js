$(document).ready(function () {
    // Handle Create User form submission
    $('#createUserForm').submit(function (e) {
        e.preventDefault();

        var formData = $(this).serialize();

        $.post('/User/Create', formData, function (response) {
            if (response.success) {
                // Update user list
                // This will depend on the format of your response
                // For example, you might add a new row to the table
            } else {
                // Handle error
            }
        });
    });

    // Handle Edit User button click
    $('.editButton').click(function () {
        var userId = $(this).data('id');

        $.get('/User/Details/' + userId, function (response) {
            // Populate the edit form with the user details
            $('#editUserId').val(response.userId);
            $('#editUsername').val(response.username);
            $('#editPassword').val(response.password);
            $('#editEmail').val(response.email);

            // Show the edit user modal
            $('#editUserModal').show();
        });
    });

    // Handle Edit User form submission
    $('#editUserForm').submit(function (e) {
        e.preventDefault();

        var formData = $(this).serialize();

        $.post('/User/Edit/' + $('#editUserId').val(), formData, function (response) {
            if (response.success) {
                // Update user list
                // This will depend on the format of your response
                // For example, you might update the row in the table
            } else {
                // Handle error
            }
        });
    });

    // Handle Delete User button click
    $('.deleteButton').click(function () {
        var userId = $(this).data('id');

        // Populate the delete form with the user id
        $('#deleteUserId').val(userId);

        // Show the delete user modal
        $('#deleteUserModal').show();
    });

    // Handle Delete User form submission
    $('#deleteUserForm').submit(function (e) {
        e.preventDefault();

        var userId = $('#deleteUserId').val();

        $.post('/User/Delete/' + userId, function (response) {
            if (response.success) {
                // Update user list
                // This will depend on the format of your response
                // For example, you might remove the row from the table
            } else {
                // Handle error
            }
        });
    });
});
