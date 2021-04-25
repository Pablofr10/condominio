import axios from 'axios'

const interceptor = axios.interceptors.response.use(
  response => response,
  error => {
    // Reject promise if usual error
    if (errorResponse.status !== 401) {
      return Promise.reject(error)
    }

    /*
     * When response code is 401, try to refresh the token.
     * Eject the interceptor so it doesn't loop in case
     * token refresh causes the 401 response
     */
    axios.interceptors.response.eject(interceptor)

    return axios
      .post('/api/refresh_token', {
        refresh_token: this._getToken('refresh_token')
      })
      .then(response => {
        error.response.config.headers['Authorization'] =
          'Bearer ' + response.data.access_token
        return axios(error.response.config)
      })
      .catch(error => {
        destroyToken()
        this.router.push('/login')
        return Promise.reject(error)
      })
      .finally(createAxiosResponseInterceptor)
  }
)

export default interceptor
