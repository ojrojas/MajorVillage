class HttpClient {

    private headers: Headers;
    constructor() {
        this.headers = new Headers();
    }

    public Post = async <T>(url: string, body: any): Promise<T> => {
        try {
            this.headers.delete("Content-Type");
            this.headers.append("Content-Type", "application/x-www-form-urlencoded");
            this.headers.append("Accept", "*/*");
            const response = await fetch(url, { method: 'post', body: body, headers: this.headers });
            return response.json() as T;
        } catch (error) {
            throw Error(`Error ${error}`);
        }
    }
}

export default HttpClient;