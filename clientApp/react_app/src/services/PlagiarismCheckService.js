class PlagiarismCheckService {
    _apiBase = 'http://localhost:5248/api/'
    _plagiarismCheckUrl = `${this._apiBase + 'plagiarismCheck'}`;

    async plagiarismCheck(text){
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ text: text })
        };
        const response = await
            fetch('http://localhost:5248/api/plagiarismCheck', requestOptions);
        const data = await response.json();

        return data;
    }
}

export default PlagiarismCheckService;