class ApiBaseService {
    static _apiBase = 'https://api.synword.com/';
    static guestRegisterUrl = `${this._apiBase + 'guestRegister'}`;
    static guestAuthenticateUrl = `${this._apiBase + 'guestAuthenticate'}`;
    static plagiarismCheckUrl = `${this._apiBase + 'plagiarismCheck'}`;
    static rephraseUrl = `${this._apiBase + 'rephrase'}`;

    static async postRequest(url, headers, form, signal) {
        const requestOptions = {
            method: 'POST',
            headers: headers,
            body: form,
            signal: signal
        };

        const response = await
            fetch(url, requestOptions);

        const data = await response.json();

        if (response.status != 200) {
            throw data;
        }

        return data;
    }
}

export default ApiBaseService;