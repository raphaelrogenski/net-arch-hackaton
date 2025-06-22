namespace NetArchHackaton.Shared.Application.Auth.Validators
{
    internal static class CPFValidator
    {
        internal static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            if (cpf.Length != 11)
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            int[] weights1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] weights2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            return CheckDigit(cpf, 9, weights1) && CheckDigit(cpf, 10, weights2);
        }

        private static bool CheckDigit(string cpf, int baseLength, int[] weights)
        {
            int sum = cpf
                .Take(baseLength)
                .Select((ch, i) => int.Parse(ch.ToString()) * weights[i])
                .Sum();

            int remainder = sum % 11;
            int expectedDigit = remainder < 2 ? 0 : 11 - remainder;

            return expectedDigit == int.Parse(cpf[baseLength].ToString());
        }
    }
}
