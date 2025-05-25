    <!-- Versión sin jQuery - JavaScript Vanilla moderno -->
    <script>
        // Esperar a que cargue la página (sin jQuery)
        document.addEventListener('DOMContentLoaded', function() {
            // Auto-focus en el campo usuario
            const usernameField = document.querySelector('#UserName');
            if (usernameField) {
                usernameField.focus();
            }
            
            // Permitir Enter para enviar formulario
            document.addEventListener('keypress', function(e) {
                if (e.key === 'Enter') {
                    const form = document.querySelector('form');
                    if (form) {
                        form.submit();
                    }
                }
            });
            
            // Si hay error, enfocar el primer campo con error
            const errorField = document.querySelector('.text-danger');
            if (errorField) {
                const inputField = errorField.previousElementSibling;
                if (inputField && inputField.tagName === 'INPUT') {
                    inputField.focus();
                }
            }
        });
    </script>
